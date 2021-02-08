using System;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace COMP2001_API.Models
{
    public partial class COMP2001_JKhanContext : DbContext
    {
        public COMP2001_JKhanContext()
        {
        }

        public COMP2001_JKhanContext(DbContextOptions<COMP2001_JKhanContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Password> Passwords { get; set; }
        public virtual DbSet<Session> Sessions { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=socem1.uopnet.plymouth.ac.uk;Database=COMP2001_JKhan;User Id=JKhan; Password=JdkP988+");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Password>(entity =>
            {
                entity.ToTable("passwords");

                entity.Property(e => e.PasswordId)
                    .ValueGeneratedNever()
                    .HasColumnName("PasswordID");

                entity.Property(e => e.DateChanged).HasColumnType("datetime");

                entity.Property(e => e.PreviousPasswords)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Passwords)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PreviousPassword");
            });

            modelBuilder.Entity<Session>(entity =>
            {
                entity.ToTable("sessions");

                entity.Property(e => e.SessionId)
                    .ValueGeneratedNever()
                    .HasColumnName("SessionID");

                entity.Property(e => e.DateIssued).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Sessions)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Session");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.UserId)
                    .ValueGeneratedNever()
                    .HasColumnName("UserID");

                entity.Property(e => e.EmailAddress)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(128);

                //entity.Property(e => e.Salt).HasMaxLength(36);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public bool Validate(User user, int id)
        {
            SqlParameter[] values = { new SqlParameter("@id", id.ToString()),
                                      new SqlParameter("@firstName", user.FirstName.ToString()),
                                      new SqlParameter("@LastName", user.LastName.ToString()),
                                      new SqlParameter("@password", user.Password.ToString())};

            bool verify;
            var test = Database.ExecuteSqlRaw("EXEC ValidateUser @id, @firstName, @LastName, @password", values);
            if (test == 1)
            {
                verify = true;
            }
            else
            {
                verify = false;
            }
            return verify;
        }

        public void Register(User user, out string responseMessage)
        {
            SqlParameter message = new SqlParameter("@ResponseMessage", "");
            message.Direction = System.Data.ParameterDirection.Output;
            message.Size = 30;

            SqlParameter[] sqlParameters = {
                new SqlParameter("@firstName", user.FirstName.ToString()),
                new SqlParameter("@lastName", user.LastName.ToString()),
                new SqlParameter("@email", user.EmailAddress.ToString()),
                new SqlParameter("@password", user.Password.ToString()),
                message
            };

            Database.ExecuteSqlRaw("EXEC Register @firstName, @lastName, @email, @password, @ResponseMessage OUTPUT", sqlParameters);

            responseMessage = message.Value.ToString();

        }

        public void Update(User user, int id)
        {
            SqlParameter[] values = {   new SqlParameter("@firstName", user.FirstName.ToString()),
                                        new SqlParameter("@lastName", user.LastName.ToString()),
                                        new SqlParameter("@email", user.EmailAddress.ToString()),
                                        new SqlParameter("@password", user.Password.ToString()),
                                        new SqlParameter("@id", id.ToString())};

            Database.ExecuteSqlRaw("EXEC UpdateUser @firstName, @lastName, @email, @password, @id", values);
        }

        public void Delete(int id)
        {
            SqlParameter[] values = {   new SqlParameter("@id", id.ToString())};

            Database.ExecuteSqlRaw("EXEC UpdateUser @id", values);

        }

    }
}
