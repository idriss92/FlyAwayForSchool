using System;
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

namespace FlyAwayForSchool.CodeToUse
{

    public class UseJson
    {
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
    }
}