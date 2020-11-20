using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace smartfy.portal_api.domain.Entities
{
    public class File : Entity, IEntityTypeConfiguration<File>
    {
        public string Name { get; set; }
        public string Extension { get; set; }
        public string FullPath { get; set; }
        public string DirectoryName { get; set; }
        public DateTime DtCopy { get; set; }
        public DateTime LastAccessTime { get; set; }
        public DateTime LastWriteTime { get; set; }
        public int HashCode { get; set; }
        public string Checksum { get; set; }
        public long Length { get; set; }
        public Guid CameraId { get; set; }
        public virtual Camera Camera { get; set; }
        public Guid DiskId { get; set; }
        public virtual Disk Disk { get; set; }
        public File() { }

        public File(
            Guid diskId,
            Guid cameraId,
            string name, 
            string extension, 
            string fullPath, 
            string directoryName, 
            DateTime dtCopy, 
            long length)
        {
            CameraId = cameraId;
            Name = name;
            Extension = extension;
            FullPath = fullPath;
            DirectoryName = directoryName;
            DtCopy = dtCopy;
            Length = length;
            DiskId = diskId;
        }

        public void Configure(EntityTypeBuilder<File> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.CameraId).IsRequired();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Length).IsRequired();
            builder.Property(x => x.FullPath).IsRequired();
            builder.Property(x => x.DirectoryName).IsRequired();
            builder.Property(x => x.DtCopy).IsRequired();

            builder.HasOne(curr => curr.Disk)
                .WithMany(fk => fk.Files)
                .HasForeignKey(f => f.DiskId)
                .IsRequired();

            builder.HasOne(curr => curr.Camera)
                .WithMany(fk => fk.Files)
                .HasForeignKey(f => f.CameraId)
                .IsRequired();
        }
    }
}