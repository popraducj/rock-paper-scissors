using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RockPaperScissors.WebApi.Models
{
    public class ParsedExternalAccessToken
    {
        public string user_id { get; set; }
        public string app_id { get; set; }
    }
}