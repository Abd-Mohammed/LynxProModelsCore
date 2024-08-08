
using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public class ActiveAlertBlob : TenantAware, ITenantAware, IFranchiseAware
    {
        public int ActiveAlertBlobId { get; set; }

        [Display(Name = "Alert", Description = "Alert Id")]
        public int AlertId { get; set; }

        public int FranchiseId { get; set; }

        [Required]
        [Display(Name = "Blob Name", Description = "Alert Blob Name")]
        public string BlobName { get; set; }

        public virtual ActiveAlert Alert { get; set; }

        public BlobDataType DataType { get { return GetDataType(BlobName); } }

        public static BlobDataType GetDataType(string blobName)
        {
            return blobName.EndsWith(".mp4") ? BlobDataType.Video : BlobDataType.Image;
        }
    }
}