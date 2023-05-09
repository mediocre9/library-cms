using System.Data;

namespace LibraryCMS.Controller
{
    /// <summary>
    /// A generic interface controller.
    /// </summary>
    /// <typeparam name="T">Model Classes</typeparam>
    public interface IController<T>
    {
        public void AddRecord(T entity);
        public void DeleteRecord(string data);
        public void UpdateRecord(string data);
        public DataTable SearchRecord(string data);
        public DataTable GetAllRecords();
    }
}
