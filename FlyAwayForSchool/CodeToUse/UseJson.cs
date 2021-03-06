﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Web.Mvc;
using FlyAwayForSchool.Models;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Net;
using System.Xml.Linq;
using System.Net.Mail;
using System.Text;

namespace FlyAwayForSchool.CodeToUse
{

    public class UseJson
    {
        static string apiServerKey = "AIzaSyCOZxft33524PDQiaHqJnrfYMxFGKVyitA";
        Dictionary<string, string> rendu;
        private FlyAwayDataEntities entities = new FlyAwayDataEntities();
        public UseJson()
        {
            rendu = new Dictionary<string, string>();
        }
        public Dictionary<string,string> ReadJsonFile(string file)
        {
            //JObject parseData = 
            
            StreamReader re = new StreamReader(file);
            JsonTextReader reder = new JsonTextReader(re);
            JsonSerializer se = new JsonSerializer();
            JObject parseDat = (JObject)se.Deserialize(reder);
            //int i = 1;
            //foreach (var item in parseDat["aeroports"])
            //{

            //    string a = item["pays"].ToString();
            //    string c = item["aeroport"].ToString();
            //    string b = item["ville"].ToString();
            //    using (FlyAwayDataEntities entities = new FlyAwayDataEntities())
            //    {
            //        string d = "data source=SI-PC;initial catalog=FlyAwayData;integrated security=sspi";
            //        SqlConnection connect = new SqlConnection(d);
            //        SqlCommand cmd = new SqlCommand("InsertOfficielAeroport", connect);
            //        cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //        SqlParameter pays = new SqlParameter("Pays", SqlDbType.NVarChar);
            //        SqlParameter aeroport = new SqlParameter("Aeroport", SqlDbType.NVarChar);
            //        SqlParameter ville = new SqlParameter("Ville", SqlDbType.NVarChar);
            //        pays.Value = a;
            //        aeroport.Value = c;
            //        ville.Value = b;
            //        cmd.Parameters.Add(pays);
            //        cmd.Parameters.Add(aeroport);
            //        cmd.Parameters.Add(ville);

            //        connect.Open();
            //        cmd.ExecuteNonQuery();
            //        connect.Close();

            //        //FlyAway.Models.AeroportOfficiel aero = new FlyAway.Models.AeroportOfficiel(i,a, b, c);//new AeroportOfficiel(a, b, c);
            //        //var x = (AeroportOfficiel)aero;
            //        //entities.AeroportOfficiel.Add(x);
            //        //entities.SaveChanges();
            //        i++;
            //    }
                

            //    //try
            //    //{
            //    //    rendu.Add(a,b+"("+c+")");
            //    //}
            //    //catch (Exception e) {
            //    //    Console.WriteLine(e.Message);
            //    //}
            //}
            return rendu;
        }



        public IHtmlString ReadDictionnary(string file)
        {
            rendu = ReadJsonFile(file);
//            Dictionary<string, string> rendu
            foreach (var gt in rendu)
            {
                Console.WriteLine(gt.Key +":"+gt.Value);
            }
            return MvcHtmlString.Create("");
        }


        public List<SelectListItem> Retourne()
        {
            //FlyAwayDataEntities db = new FlyAwayDataEntities();
            List<SelectListItem> listSelect = new List<SelectListItem>();

            foreach (var aero in entities.AeroportOfficiel)
            {
                listSelect.Add(new SelectListItem { Text = aero.Aeroport });

            }

            return listSelect;

        }

        public List<SelectListItem> RetournePolitique()
        {
            List<SelectListItem> listSelect = new List<SelectListItem>();

            foreach (var aero in entities.Politique)
            {
                listSelect.Add(new SelectListItem { Text = aero.NomPolitique });

            }

            return listSelect;
        }

        public int CalculDistance(string depart, string arrivee)
        {
            WebClient client = new WebClient();
            Stream stream = client.OpenRead("https://maps.googleapis.com/maps/api/distancematrix/xml?origins="+depart+"&destinations="+arrivee+"&mode=driving&language=fr-FR&key="+apiServerKey);
            //?origins=Vancouver+BC|Seattle&destinations=San+Francisco|Vancouver+BC&mode=bicycling&language=fr-FR&key=false");
            //var depart = new 
            XDocument doc = XDocument.Load(stream);
            var distance = (string)doc.Root
                          .Element("row")
                          .Element("element")
                          .Element("distance")
                          .Element("value");
            return Int32.Parse( distance);
        }

        public int CalculDuree(string depart, string arrivee)
        {
            WebClient client = new WebClient();
            Stream stream = client.OpenRead("https://maps.googleapis.com/maps/api/distancematrix/xml?origins=" + depart + "&destinations=" + arrivee + "&mode=driving&language=fr-FR&key=" + apiServerKey);
            XDocument doc = XDocument.Load(stream);

            var duration = (string)doc.Root
              .Element("row")
              .Element("element")
              .Element("duration")
              .Element("value");
            return Int32.Parse(duration);
        }

        public void SendMail(Reservations reservation)
        {
            MailMessage mail = new MailMessage();
            FlyAwayDataEntities entities = new FlyAwayDataEntities();
            
            mail.To.Add(reservation.UserMail);
            StringBuilder contentMail = new StringBuilder("Bonjour "+ reservation.UserMail);
            mail.From = new MailAddress("contacteasyflight@gmail.com");
            mail.Subject = "Validation de Réservation sur Easy Flight";
            contentMail.AppendFormat("Votre réservation pour le vol {0} à {1} , a été pris en compte", entities.Vols.ToList().Single(c => c.Id == reservation.IdVol).Depart, entities.Vols.ToList().Single(c => c.Id == reservation.IdVol).Arrivee);
            contentMail.AppendFormat("N'oubliez pas de vous acquitter des frais de voyages s'élevant à {0}", entities.Vols.ToList().Single(c => c.Id == reservation.IdVol).Prix);
            contentMail.AppendLine("Cordialement,");
            contentMail.AppendLine("Le Service Client");
            //string Body = "Bonjour, \n Votre réservation . N'oubliez pas de vous acquitter des frais de voyage. \n Cordialement, \n Le service Client ";
            mail.Body = contentMail.ToString(); ;
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();

            smtp.Host = "smtp.gmail.com";
            smtp.Port = 25;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential
            (mail.From.ToString(), "mamadoudavid");// Enter seders User name and password
            smtp.EnableSsl = true;
            smtp.Send(mail);
        }

        public  String ConvertTime(String heure)
        {
            string[] tableauHeure = heure.Split(':');
            DateTime useToGetHour = new DateTime(1, 1, 1, int.Parse(tableauHeure[0]),int.Parse(tableauHeure[1]), 0);
            return useToGetHour.TimeOfDay.ToString();
        }

        public String ConvertTimeAddTime(String heure, double seconde)
        {
            string[] tableauHeure = heure.Split(':');
            DateTime useToGetHour = new DateTime(1, 1, 1, int.Parse(tableauHeure[0]), int.Parse(tableauHeure[1]), 0);
            useToGetHour = useToGetHour.AddSeconds(seconde);
            return useToGetHour.TimeOfDay.ToString();
        }

        

    }
}