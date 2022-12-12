using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppManager.Entities
{
    [Table("FileManage")]
    public class FileManageEntity : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string FilePath { get; set; }
        public string FileType { get; set; }
        public string FileFormat { get; set; }
    }
}
