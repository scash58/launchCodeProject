using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using VehicleInventory.Interfaces;

namespace VehicleInventory
{
    public class VehiclesDB
    {
        private HashSet<VehicleBase> vehicles;
        private string filename;

        private static bool ReMatch(string input, string pattern)
        {
            return Regex.IsMatch(input, pattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase);
        }

        private static bool MatchVehicle(VehicleBase v, string sv)
        {
            return ReMatch(v.Make, Regex.Escape(sv)) || ReMatch(v.Model, Regex.Escape(sv));
        }

        public VehiclesDB(string fn)
        {
            this.vehicles = new HashSet<VehicleBase>();
            this.filename = fn;
        }

        public bool SaveDB()
        {
            FileStream fs = new FileStream(this.filename, FileMode.Create);
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, this.vehicles);
            }
            catch (SerializationException e)
            {
                return false;
            }
            finally
            {
                fs.Close();
            }
            return true;
        }

        public bool LoadDB()
        {
            if (!File.Exists(this.filename)) return true;
            FileStream fs = new FileStream(this.filename, FileMode.Open);
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                this.vehicles = formatter.Deserialize(fs) as HashSet<VehicleBase>;
            }
            catch (SerializationException e)
            {
                return false;
            }
            finally
            {
                fs.Close();
            }
            return true;
        }

        public HashSet<VehicleBase> Vehicles
        {
            get
            {
                return this.vehicles;
            }
        }

        public bool Add(VehicleBase e)
        {
            return this.vehicles.Add(e);
        }

        public int Count
        {
            get
            {
                return this.vehicles.Count;
            }
        }

        public IEnumerable<VehicleBase> Find(Func<VehicleBase, bool> comp)
        {
            return this.vehicles.Where(comp);
        }

        public IEnumerable<VehicleBase> FindIDs(string id, bool full = false)
        {
            return this.Find(v => ReMatch(v._ID, "^" + Regex.Escape(id) + (full ? "$" : "")));
        }

        public VehicleBase FindFirstID(string id, bool full = false)
        {
            IEnumerable<VehicleBase> res = this.FindIDs(id, full);
            if (res.Count() < 1) return null;
            return res.First();
        }

        public bool Remove(VehicleBase v)
        {
            return this.vehicles.Remove(v);
        }

        public IEnumerable<VehicleBase> Search(string sv)
        {
            return this.Find(v => MatchVehicle(v, sv));
        }

        public void PrintDB()
        {
            foreach (VehicleBase v in this.vehicles) { v.PrintDescription(); }
        }

    }
}
