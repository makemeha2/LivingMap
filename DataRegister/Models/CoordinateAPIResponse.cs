using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRegister.Models
{
    public class CoordinateAPIResponse
    {
        public Response Response { get; set; } = new();
    }

    public class Response
    {
        public Service Service { get; set; } = new();
        public string Status { get; set; } = "FAIL";
        public Input Input { get; set; } = new();
        public Refined Refined { get; set; } = new();
        public Result Result { get; set; } = new();
    }

    public class Service
    {
        public string Name { get; set; } = string.Empty;
        public string Version { get; set; } = string.Empty;
        public string Operation { get; set; } = string.Empty;
        public string Time { get; set; } = string.Empty;
    }

    public class Input
    {
        public string Type { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
    }

    public class Refined
    {
        public string Text { get; set; } = string.Empty;
        public Structure Structure { get; set; } = new();
    }

    public class Structure
    {
        public string Level0 { get; set; } = string.Empty;
        public string Level1 { get; set; } = string.Empty;
        public string Level2 { get; set; } = string.Empty;
        public string Level3 { get; set; } = string.Empty;
        public string Level4L { get; set; } = string.Empty;
        public string Level4LC { get; set; } = string.Empty;
        public string Level4A { get; set; } = string.Empty;
        public string Level4AC { get; set; } = string.Empty;
        public string Level5 { get; set; } = string.Empty;
        public string Detail { get; set; } = string.Empty;
    }

    public class Result
    {
        public string Crs { get; set; } = string.Empty;
        public Point Point { get; set; } = new Point();
    }

    public class Point
    {
        public string X { get; set; } = "-999";
        public string Y { get; set; } = "-999";
    }
}
