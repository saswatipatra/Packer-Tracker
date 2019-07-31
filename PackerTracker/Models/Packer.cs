using System.Collections.Generic;

namespace PackerTracker.Models
{
  public class Packer
    {
        public string ItemName { get; set; }
        public int ItemPrice{ get; set;}
        public bool Purchased {get; set;}
        public bool Packed {get; set;}
        public int Id{get; }
        private static List<Packer> _instances = new List<Packer> {};

        public Packer (string itemName, int itemPrice, bool purchased, bool packed)
        {
            ItemName= itemName;
            ItemPrice= itemPrice;
            Purchased = purchased;
            Packed= packed;
            _instances.Add(this);
            Id= _instances.Count;
        }

        public static List<Packer> GetAll()
        {
            return _instances;
        }

        public static void ClearAll()
        {
            _instances.Clear();
        }

        public static Packer Search( int searchId)
        {
            return _instances[searchId-1];
        }
    }
}