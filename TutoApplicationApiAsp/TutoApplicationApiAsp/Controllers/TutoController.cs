using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace TutoApplicationApiAsp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TutoController : Controller
    {

        private readonly ILogger<TutoController> _logger;

        public TutoController(ILogger<TutoController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Tuto> Get()
        {
            string cs = @"server=localhost;userid=root;password=root;database=bdformation;SSL Mode=None";
            MySqlConnection con = new MySqlConnection(cs);
            con.Open();

            string sql = "SELECT title,price,img,description from tutos";
            using var cmd = new MySqlCommand(sql, con);
            using MySqlDataReader rcr = cmd.ExecuteReader();

            int nbTuto = 6;
            Tuto[] formations = new Tuto[nbTuto];

            int cpt = 0;

            while (rcr.Read() && cpt < nbTuto)
            {
                Tuto t = new Tuto { titre = rcr[0].ToString(), price = (int) rcr[1], img = rcr[0].ToString(), desc = rcr[0].ToString() };
                
                formations[cpt] = t;
                cpt++;
            }

            return formations;
        }
        [HttpGet]
        [Route("index")]
        public Tuto GetByIndex(int i)
        {
            string cs = @"server=localhost;userid=root;password=root;database=bdformation";
            MySqlConnection con = new MySqlConnection(cs);
            con.Open();

            string sql = "SELECT title,price,img,description from tutos";
            using var cmd = new MySqlCommand(sql, con);
            using MySqlDataReader rcr = cmd.ExecuteReader();

            int nbTuto = 6;
            Tuto[] formations = new Tuto[nbTuto];

            int cpt = 0;

            while (rcr.Read() && cpt < nbTuto)
            {
                Tuto t = new Tuto { titre = rcr[0].ToString(), price = (int)rcr[1], img = rcr[0].ToString(), desc = rcr[0].ToString() };

                formations[cpt] = t;
                cpt++;
            }

            return formations[i];
  
        }






    }
}
