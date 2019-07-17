using Share.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.Business
{
    public class ToolRepository
    {
        public List<Tool> GetAllTools()
        {
            ShareDBEntities context = new ShareDBEntities();
            List<Tool> tools = context.Tools.ToList();
            return tools;
        }
        public Tool GetToolById(int id)
        {
            ShareDBEntities context = new ShareDBEntities();
            Tool tool = context.Tools.Find(id);
            return tool;
        }
        public void Add(Tool tool)
        {
            ShareDBEntities context = new ShareDBEntities();
            context.Tools.Add(tool);
            context.SaveChanges();

        }
        public void Delete(int id)
        {
            ShareDBEntities context = new ShareDBEntities();
            Tool tool = context.Tools.Find(id);
            context.Tools.Remove(tool);
            context.SaveChanges();
        }
        public void Update(Tool tool)
        {
            ShareDBEntities context = new ShareDBEntities();
            Tool oldTool = context.Tools.Find(tool.id);
            context.Entry(oldTool).CurrentValues.SetValues(tool);
            context.SaveChanges();
        }
    }
}
