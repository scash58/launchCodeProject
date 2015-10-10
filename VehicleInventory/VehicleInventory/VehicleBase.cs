using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleInventory.Interfaces;

namespace VehicleInventory
{
    [Serializable]
    public abstract class VehicleBase: IVehicle
    {
        private string id;
        private string year;
        private string make;
        private string model;
        private string modelnum;
        private string serialnum;

        public string _ID
        {
            get { return this.id; }

            private set { this.id = value; }
        }

        public string Year
        {
            get { return this.year; }

            set { this.year = value; }

        }

        public string Make
        {
            get { return this.make; }

            set { this.make = value; }

        }

        public string Model
        {
            get { return this.model; }

            set { this.model = value; }

        }

        public string ModelNum
        {
            get { return this.modelnum; }

            set { this.modelnum = value; }

        }

        public string SerialNum
        {
            get { return this.serialnum; }

            set { this.serialnum = value; }

        }

        public VehicleBase()
        {
            this._ID = Guid.NewGuid().ToString("D");
        }

        public virtual string GetDescription()
        {
            return string.Format("Vehicle: {0}\nID: {1}\nYear: {2}\nMake: {3}\nModel: {4}\n" +
                                 "Model Number: {5}\nSerial Number: {6}", this.GetType().Name, this._ID, 
                                 this.Year, this.Make, this.Model, this.ModelNum, this.SerialNum);
        }

        public virtual void PrintDescription()
        {
            Console.WriteLine(this.GetDescription());
        }

        public virtual bool GetUserInput()
        {
            try
            {
                Console.Write("Year: ");
                this.Year = Console.ReadLine();
                Console.Write("Make: ");
                this.Make = Console.ReadLine();
                Console.Write("Model: ");
                this.Model = Console.ReadLine();
                Console.Write("Model Number: ");
                this.ModelNum = Console.ReadLine();
                Console.Write("Serial Number: ");
                this.SerialNum = Console.ReadLine();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("[ERROR]: " + e.Message);
                return false;
            }
        }

    }
}
