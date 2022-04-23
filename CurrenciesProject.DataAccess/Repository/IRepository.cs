using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CurrenciesProject.DataAccess
{
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Tüm veriyi getir.
        /// </summary>
        /// <returns></returns>
        IQueryable<T> GetAll();

        /// <summary>
        /// Veriyi Where metodu ile getir.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// İstenilen veriyi single olarak getirir.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        T Get(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Verilen entityi ekle.
        /// </summary>
        /// <param name="entity"></param>
        void Add(T entity);

        /// <summary>
        /// Verilen entityi ekle.
        /// </summary>
        /// <param name="entityList"></param>
        void BulkInsert(List<T> entityList);

        /// <summary>
        /// Verilen entity i güncelle.
        /// </summary>
        /// <param name="entity"></param>
        void Update(T entity);

        /// <summary>
        /// Verilen entityi sil.
        /// </summary>
        /// <param name="entity"></param>
        void Delete(T entity, bool forceDelete = false);

        /// <summary>
        /// predicate göre veriler silinir.
        /// </summary>
        /// <param name="predicate"></param>
        void Delete(Expression<Func<T, bool>> predicate, bool forceDelete = false);

        /// <summary>
        /// Verilen entityi sil.
        /// </summary>
        /// <param name="entityList"></param>
        void BulkDelete(List<T> entityList);

        /// <summary>
        /// Aynı kayıt eklememek için objeyi kontrol ederek true veya false dönderir.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate"></param>
        /// <returns></returns>
        bool Any(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// DbContext i verir.
        /// </summary> 
        /// <returns></returns>
        DbContext GetDbContext();
    }
}