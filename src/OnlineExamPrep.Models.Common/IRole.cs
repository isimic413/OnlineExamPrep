using System.Collections.Generic;

namespace OnlineExamPrep.Models.Common
{
    public interface IRole
    {
        string Id { get; set; }
        string Name { get; set; }
        ICollection<IUser> Users { get; set; }
    }
}
