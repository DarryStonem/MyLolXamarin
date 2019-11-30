using System;
namespace MyLoL.Models
{
    public class SummonerAzure
    {
        public string Name { get; set; }
        public long Level { get; set; }
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}