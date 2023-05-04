using _11939_Major_Agmnt_.config;
using _11939_Major_Agmnt_.models;
using _11939_Major_Agmnt_.service;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace _11939_Major_Agmnt_.controllers
{
    public interface IController<T>
    {
        public void addRecord(T entity);
        public DataTable searchRecord(string name);
        public DataTable getAllRecords();
        public void updateRecord(string name);
        public void deleteRecord(int id);
    }
}
