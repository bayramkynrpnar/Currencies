﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace CurrenciesProject.DataAccess
{
    public class UnitOfWork<T> : IDisposable, IUnitOfWork where T : class
    {
        private DbContext dbContext;
        private bool disposed = false;
        public readonly List<string> ErrorMessageList = new List<string>();
        /// <summary>
        /// Veri bağlantısı
        /// </summary>
        private DbContext DbContext
        {
            get
            {
                if (dbContext == null)
                {
                    dbContext = (DbContext)Activator.CreateInstance(typeof(T));
                }
                return dbContext;
            }
            set { dbContext = value; }
        }
        public void Dispose()
        {
            DbContext.Dispose();
            DbContext = null;
        }

        public IRepository<T> GetRepository<T>() where T : class
        {
            return new Repository<T>(DbContext);
        }

        public int SaveChanges()
        {
            int result = -1;
            try
            {
                using (TransactionScope tScope = new TransactionScope())
                {
                    result = DbContext.SaveChanges();
                    tScope.Complete();
                }
            }
            catch (ValidationException ex)
            {
                string errorString = ex.Message;
                ErrorMessageList.Add(errorString);
            }
            catch (DbUpdateException ex)
            {
                string errorString = ex.Message;
                if (ex.InnerException != null)
                {
                    errorString += ex.InnerException.Message;
                    if (ex.InnerException.InnerException != null)
                    {
                        errorString += ex.InnerException.InnerException.Message;
                    }
                }

                ErrorMessageList.Add(errorString);
            }
            catch (Exception ex)
            {
                ErrorMessageList.Add(ex.Message);
            }
            finally
            {
                if (result == -1)
                {
                    Console.WriteLine("HATA");
                }
            }
            return result;
        }
    }
}
