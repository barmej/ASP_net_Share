using Share.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.Business
{
   public class BorrowedToolRepository
    {
        public List<BorrowedTool> GetAllBorrowedTools()
        {
            ShareDBEntities context = new ShareDBEntities();
            List<BorrowedTool> borrowedTools = context.BorrowedTools.ToList();
            return borrowedTools;
        }
        public BorrowedTool GetBorrowedToolById(int id)
        {
            ShareDBEntities context = new ShareDBEntities();
            BorrowedTool borrowedTool = context.BorrowedTools.Find(id);
            return borrowedTool;
        }
        public void Add(BorrowedTool borrowedTool)
        {
            ShareDBEntities context = new ShareDBEntities();
            context.BorrowedTools.Add(borrowedTool);
            context.SaveChanges();

        }
        public void Delete(int id)
        {
            ShareDBEntities context = new ShareDBEntities();
            BorrowedTool borrowedTool = context.BorrowedTools.Find(id);
            context.BorrowedTools.Remove(borrowedTool);
            context.SaveChanges();
        }
        public void Update(BorrowedTool borrowedTool)
        {
            ShareDBEntities context = new ShareDBEntities();
            BorrowedTool oldBorrowedTool = context.BorrowedTools.Find(borrowedTool.id);
            context.Entry(oldBorrowedTool).CurrentValues.SetValues(borrowedTool);
            context.SaveChanges();
        }
    }
}

