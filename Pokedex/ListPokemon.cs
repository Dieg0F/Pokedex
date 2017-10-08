using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace Pokedex
{
    public class Result
    {
        public string url { get; set; }
        public string name { get; set; }
    }

    public class RootObject
    {
        public int count { get; set; }
        public string previous { get; set; }
        public List<Result> results { get; set; }
        public string next { get; set; }
    }
}