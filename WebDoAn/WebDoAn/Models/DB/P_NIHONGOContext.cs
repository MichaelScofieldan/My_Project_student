using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebDoAn.Models.DB
{
    public partial class P_NIHONGOContext : DbContext
    {
        public virtual DbSet<CGrammar> CGrammar { get; set; }
        public virtual DbSet<CKaiwa> CKaiwa { get; set; }
        public virtual DbSet<CKanji> CKanji { get; set; }
        public virtual DbSet<CWord> CWord { get; set; }
        public virtual DbSet<MAnswer> MAnswer { get; set; }
        public virtual DbSet<MAuthority> MAuthority { get; set; }
        public virtual DbSet<MNews> MNews { get; set; }
        public virtual DbSet<MQuestion> MQuestion { get; set; }
        public virtual DbSet<MToppic> MToppic { get; set; }
        public virtual DbSet<MUntiltbl> MUntiltbl { get; set; }
        public virtual DbSet<MUser> MUser { get; set; }

        public P_NIHONGOContext(DbContextOptions<P_NIHONGOContext> options)
: base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CGrammar>(entity =>
            {
                entity.HasKey(e => e.Grammarcode);

                entity.ToTable("C_GRAMMAR");

                entity.Property(e => e.Grammarcode)
                    .HasColumnName("GRAMMARCODE")
                    .HasMaxLength(10)
                    .ValueGeneratedNever();

                entity.Property(e => e.Attribute1)
                    .HasColumnName("ATTRIBUTE1")
                    .HasMaxLength(50);

                entity.Property(e => e.Attribute2)
                    .HasColumnName("ATTRIBUTE2")
                    .HasMaxLength(50);

                entity.Property(e => e.CreateDate)
                    .HasColumnName("CREATE_DATE")
                    .HasMaxLength(10);

                entity.Property(e => e.Description).HasColumnName("DESCRIPTION");

                entity.Property(e => e.Detail1).HasColumnName("DETAIL1");

                entity.Property(e => e.Detail2).HasColumnName("DETAIL2");

                entity.Property(e => e.Detail3).HasColumnName("DETAIL3");

                entity.Property(e => e.Example1)
                    .HasColumnName("EXAMPLE1")
                    .HasMaxLength(250);

                entity.Property(e => e.Example2)
                    .HasColumnName("EXAMPLE2")
                    .HasMaxLength(250);

                entity.Property(e => e.Example3)
                    .HasColumnName("EXAMPLE3")
                    .HasMaxLength(250);

                entity.Property(e => e.Image)
                    .HasColumnName("IMAGE")
                    .HasMaxLength(250);

                entity.Property(e => e.Index1)
                    .HasColumnName("INDEX1")
                    .HasMaxLength(250);

                entity.Property(e => e.Index2)
                    .HasColumnName("INDEX2")
                    .HasMaxLength(250);

                entity.Property(e => e.Index3)
                    .HasColumnName("INDEX3")
                    .HasMaxLength(250);

                entity.Property(e => e.Levelcode)
                    .HasColumnName("LEVELCODE")
                    .HasMaxLength(10);

                entity.Property(e => e.MeanEx1)
                    .HasColumnName("MEAN_EX1")
                    .HasMaxLength(250);

                entity.Property(e => e.MeanEx2)
                    .HasColumnName("MEAN_EX2")
                    .HasMaxLength(250);

                entity.Property(e => e.MeanEx3)
                    .HasColumnName("MEAN_EX3")
                    .HasMaxLength(250);

                entity.Property(e => e.Minacode)
                    .HasColumnName("MINACODE")
                    .HasMaxLength(10);

                entity.Property(e => e.Status)
                    .HasColumnName("STATUS")
                    .HasMaxLength(1);

                entity.Property(e => e.Title)
                    .HasColumnName("TITLE")
                    .HasMaxLength(250);

                entity.Property(e => e.Toppiccode)
                    .HasColumnName("TOPPICCODE")
                    .HasMaxLength(10);

                entity.Property(e => e.UpDate)
                    .HasColumnName("UP_DATE")
                    .HasMaxLength(10);

                entity.Property(e => e.Usercode)
                    .HasColumnName("USERCODE")
                    .HasMaxLength(10);

                entity.Property(e => e.Votenumber)
                    .HasColumnName("VOTENUMBER")
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<CKaiwa>(entity =>
            {
                entity.HasKey(e => e.Kaiwacode);

                entity.ToTable("C_KAIWA");

                entity.Property(e => e.Kaiwacode)
                    .HasColumnName("KAIWACODE")
                    .HasMaxLength(10)
                    .ValueGeneratedNever();

                entity.Property(e => e.Attribute1)
                    .HasColumnName("ATTRIBUTE1")
                    .HasMaxLength(50);

                entity.Property(e => e.Attribute2)
                    .HasColumnName("ATTRIBUTE2")
                    .HasMaxLength(50);

                entity.Property(e => e.CreateDate)
                    .HasColumnName("CREATE_DATE")
                    .HasMaxLength(10);

                entity.Property(e => e.Description).HasColumnName("DESCRIPTION");

                entity.Property(e => e.Image)
                    .HasColumnName("IMAGE")
                    .HasMaxLength(250);

                entity.Property(e => e.Kaiwaname).HasColumnName("KAIWANAME");

                entity.Property(e => e.Levelcode)
                    .HasColumnName("LEVELCODE")
                    .HasMaxLength(10);

                entity.Property(e => e.Linkdownmp3).HasColumnName("LINKDOWNMP3");

                entity.Property(e => e.Minacode)
                    .HasColumnName("MINACODE")
                    .HasMaxLength(10);

                entity.Property(e => e.Status)
                    .HasColumnName("STATUS")
                    .HasMaxLength(1);

                entity.Property(e => e.Supen).HasColumnName("SUPEN");

                entity.Property(e => e.Supjp).HasColumnName("SUPJP");

                entity.Property(e => e.Toppiccode)
                    .HasColumnName("TOPPICCODE")
                    .HasMaxLength(10);

                entity.Property(e => e.UpDate)
                    .HasColumnName("UP_DATE")
                    .HasMaxLength(10);

                entity.Property(e => e.Usercode)
                    .HasColumnName("USERCODE")
                    .HasMaxLength(10);

                entity.Property(e => e.Votenumber)
                    .HasColumnName("VOTENUMBER")
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<CKanji>(entity =>
            {
                entity.HasKey(e => e.Kanjicode);

                entity.ToTable("C_KANJI");

                entity.Property(e => e.Kanjicode)
                    .HasColumnName("KANJICODE")
                    .HasMaxLength(10)
                    .ValueGeneratedNever();

                entity.Property(e => e.Attribute1)
                    .HasColumnName("ATTRIBUTE1")
                    .HasMaxLength(50);

                entity.Property(e => e.Attribute2)
                    .HasColumnName("ATTRIBUTE2")
                    .HasMaxLength(50);

                entity.Property(e => e.CreateDate)
                    .HasColumnName("CREATE_DATE")
                    .HasMaxLength(10);

                entity.Property(e => e.Description).HasColumnName("DESCRIPTION");

                entity.Property(e => e.Example1)
                    .HasColumnName("EXAMPLE1")
                    .HasMaxLength(250);

                entity.Property(e => e.Example2)
                    .HasColumnName("EXAMPLE2")
                    .HasMaxLength(250);

                entity.Property(e => e.Example3)
                    .HasColumnName("EXAMPLE3")
                    .HasMaxLength(250);

                entity.Property(e => e.Hanviet)
                    .HasColumnName("HANVIET")
                    .HasMaxLength(50);

                entity.Property(e => e.Hinhve)
                    .HasColumnName("HINHVE")
                    .HasMaxLength(250);

                entity.Property(e => e.Image)
                    .HasColumnName("IMAGE")
                    .HasMaxLength(250);

                entity.Property(e => e.Kunyomi)
                    .HasColumnName("KUNYOMI")
                    .HasMaxLength(50);

                entity.Property(e => e.Levelcode)
                    .HasColumnName("LEVELCODE")
                    .HasMaxLength(10);

                entity.Property(e => e.MeanEx1)
                    .HasColumnName("MEAN_EX1")
                    .HasMaxLength(250);

                entity.Property(e => e.MeanEx2)
                    .HasColumnName("MEAN_EX2")
                    .HasMaxLength(250);

                entity.Property(e => e.MeanEx3)
                    .HasColumnName("MEAN_EX3")
                    .HasMaxLength(250);

                entity.Property(e => e.Minacode)
                    .HasColumnName("MINACODE")
                    .HasMaxLength(10);

                entity.Property(e => e.Nghiaviet)
                    .HasColumnName("NGHIAVIET")
                    .HasMaxLength(250);

                entity.Property(e => e.Onomi)
                    .HasColumnName("ONOMI")
                    .HasMaxLength(50);

                entity.Property(e => e.Status)
                    .HasColumnName("STATUS")
                    .HasMaxLength(1);

                entity.Property(e => e.Topiccode)
                    .HasColumnName("TOPICCODE")
                    .HasMaxLength(10);

                entity.Property(e => e.UpDate)
                    .HasColumnName("UP_DATE")
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<CWord>(entity =>
            {
                entity.HasKey(e => e.Wordcode);

                entity.ToTable("C_WORD");

                entity.Property(e => e.Wordcode)
                    .HasColumnName("WORDCODE")
                    .HasMaxLength(10)
                    .ValueGeneratedNever();

                entity.Property(e => e.Attribute1)
                    .HasColumnName("ATTRIBUTE1")
                    .HasMaxLength(50);

                entity.Property(e => e.Attribute2)
                    .HasColumnName("ATTRIBUTE2")
                    .HasMaxLength(50);

                entity.Property(e => e.CreateDate)
                    .HasColumnName("CREATE_DATE")
                    .HasMaxLength(10);

                entity.Property(e => e.Description).HasColumnName("DESCRIPTION");

                entity.Property(e => e.Example1)
                    .HasColumnName("EXAMPLE1")
                    .HasMaxLength(250);

                entity.Property(e => e.Example2)
                    .HasColumnName("EXAMPLE2")
                    .HasMaxLength(250);

                entity.Property(e => e.Example3)
                    .HasColumnName("EXAMPLE3")
                    .HasMaxLength(250);

                entity.Property(e => e.Hanviet)
                    .HasColumnName("HANVIET")
                    .HasMaxLength(50);

                entity.Property(e => e.Hiragana)
                    .HasColumnName("HIRAGANA")
                    .HasMaxLength(50);

                entity.Property(e => e.Image)
                    .HasColumnName("IMAGE")
                    .HasMaxLength(250);

                entity.Property(e => e.Kanji)
                    .HasColumnName("KANJI")
                    .HasMaxLength(50);

                entity.Property(e => e.Katakana)
                    .HasColumnName("KATAKANA")
                    .HasMaxLength(50);

                entity.Property(e => e.Levelcode)
                    .HasColumnName("LEVELCODE")
                    .HasMaxLength(10);

                entity.Property(e => e.MeanEx1)
                    .HasColumnName("MEAN_EX1")
                    .HasMaxLength(250);

                entity.Property(e => e.MeanEx2)
                    .HasColumnName("MEAN_EX2")
                    .HasMaxLength(250);

                entity.Property(e => e.MeanEx3)
                    .HasColumnName("MEAN_EX3")
                    .HasMaxLength(250);

                entity.Property(e => e.Minacode)
                    .HasColumnName("MINACODE")
                    .HasMaxLength(10);

                entity.Property(e => e.Nghiaviet)
                    .HasColumnName("NGHIAVIET")
                    .HasMaxLength(250);

                entity.Property(e => e.Status)
                    .HasColumnName("STATUS")
                    .HasMaxLength(1);

                entity.Property(e => e.Topiccode)
                    .HasColumnName("TOPICCODE")
                    .HasMaxLength(10);

                entity.Property(e => e.UpDate)
                    .HasColumnName("UP_DATE")
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<MAnswer>(entity =>
            {
                entity.HasKey(e => e.Answercode);

                entity.ToTable("M_ANSWER");

                entity.Property(e => e.Answercode)
                    .HasColumnName("ANSWERCODE")
                    .HasMaxLength(10)
                    .ValueGeneratedNever();

                entity.Property(e => e.Attribute1)
                    .HasColumnName("ATTRIBUTE1")
                    .HasMaxLength(50);

                entity.Property(e => e.Attribute2)
                    .HasColumnName("ATTRIBUTE2")
                    .HasMaxLength(50);

                entity.Property(e => e.CreateDate)
                    .HasColumnName("CREATE_DATE")
                    .HasMaxLength(10);

                entity.Property(e => e.Description).HasColumnName("DESCRIPTION");

                entity.Property(e => e.Questioncode)
                    .HasColumnName("QUESTIONCODE")
                    .HasMaxLength(10);

                entity.Property(e => e.Status)
                    .HasColumnName("STATUS")
                    .HasMaxLength(1);

                entity.Property(e => e.UpDate)
                    .HasColumnName("UP_DATE")
                    .HasMaxLength(10);

                entity.Property(e => e.Usercode)
                    .HasColumnName("USERCODE")
                    .HasMaxLength(10);

                entity.Property(e => e.Votenumber)
                    .HasColumnName("VOTENUMBER")
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<MAuthority>(entity =>
            {
                entity.HasKey(e => e.Authocode);

                entity.ToTable("M_AUTHORITY");

                entity.Property(e => e.Authocode)
                    .HasColumnName("AUTHOCODE")
                    .HasMaxLength(10)
                    .ValueGeneratedNever();

                entity.Property(e => e.Attribute1)
                    .HasColumnName("ATTRIBUTE1")
                    .HasMaxLength(50);

                entity.Property(e => e.Attribute2)
                    .HasColumnName("ATTRIBUTE2")
                    .HasMaxLength(50);

                entity.Property(e => e.Authoname)
                    .HasColumnName("AUTHONAME")
                    .HasMaxLength(50);

                entity.Property(e => e.CreateDate)
                    .HasColumnName("CREATE_DATE")
                    .HasMaxLength(10);

                entity.Property(e => e.Description).HasColumnName("DESCRIPTION");

                entity.Property(e => e.Status)
                    .HasColumnName("STATUS")
                    .HasMaxLength(1);

                entity.Property(e => e.UpDate)
                    .HasColumnName("UP_DATE")
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<MNews>(entity =>
            {
                entity.HasKey(e => e.Newscode);

                entity.ToTable("M_NEWS");

                entity.Property(e => e.Newscode)
                    .HasColumnName("NEWSCODE")
                    .HasMaxLength(10)
                    .ValueGeneratedNever();

                entity.Property(e => e.Attribute1)
                    .HasColumnName("ATTRIBUTE1")
                    .HasMaxLength(50);

                entity.Property(e => e.Attribute2)
                    .HasColumnName("ATTRIBUTE2")
                    .HasMaxLength(50);

                entity.Property(e => e.CreateDate)
                    .HasColumnName("CREATE_DATE")
                    .HasMaxLength(10);

                entity.Property(e => e.Description).HasColumnName("DESCRIPTION");

                entity.Property(e => e.Detail1).HasColumnName("DETAIL1");

                entity.Property(e => e.Detail2).HasColumnName("DETAIL2");

                entity.Property(e => e.Detail3).HasColumnName("DETAIL3");

                entity.Property(e => e.Image)
                    .HasColumnName("IMAGE")
                    .HasMaxLength(250);

                entity.Property(e => e.Index1)
                    .HasColumnName("INDEX1")
                    .HasMaxLength(250);

                entity.Property(e => e.Index2)
                    .HasColumnName("INDEX2")
                    .HasMaxLength(250);

                entity.Property(e => e.Index3)
                    .HasColumnName("INDEX3")
                    .HasMaxLength(250);

                entity.Property(e => e.Newstitle).HasColumnName("NEWSTITLE");

                entity.Property(e => e.Status)
                    .HasColumnName("STATUS")
                    .HasMaxLength(1);

                entity.Property(e => e.Toppiccode)
                    .HasColumnName("TOPPICCODE")
                    .HasMaxLength(10);

                entity.Property(e => e.UpDate)
                    .HasColumnName("UP_DATE")
                    .HasMaxLength(10);

                entity.Property(e => e.Usercode)
                    .HasColumnName("USERCODE")
                    .HasMaxLength(10);

                entity.Property(e => e.Votenumber)
                    .HasColumnName("VOTENUMBER")
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<MQuestion>(entity =>
            {
                entity.HasKey(e => e.Questioncode);

                entity.ToTable("M_QUESTION");

                entity.Property(e => e.Questioncode)
                    .HasColumnName("QUESTIONCODE")
                    .HasMaxLength(10)
                    .ValueGeneratedNever();

                entity.Property(e => e.Attribute1)
                    .HasColumnName("ATTRIBUTE1")
                    .HasMaxLength(50);

                entity.Property(e => e.Attribute2)
                    .HasColumnName("ATTRIBUTE2")
                    .HasMaxLength(50);

                entity.Property(e => e.Contentquestion).HasColumnName("CONTENTQUESTION");

                entity.Property(e => e.CreateDate)
                    .HasColumnName("CREATE_DATE")
                    .HasMaxLength(10);

                entity.Property(e => e.Description).HasColumnName("DESCRIPTION");

                entity.Property(e => e.Status)
                    .HasColumnName("STATUS")
                    .HasMaxLength(1);

                entity.Property(e => e.Toppiccode)
                    .HasColumnName("TOPPICCODE")
                    .HasMaxLength(10);

                entity.Property(e => e.UpDate)
                    .HasColumnName("UP_DATE")
                    .HasMaxLength(10);

                entity.Property(e => e.Usercode)
                    .HasColumnName("USERCODE")
                    .HasMaxLength(10);

                entity.Property(e => e.Votenumber)
                    .HasColumnName("VOTENUMBER")
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<MToppic>(entity =>
            {
                entity.HasKey(e => e.Toppiccode);

                entity.ToTable("M_TOPPIC");

                entity.Property(e => e.Toppiccode)
                    .HasColumnName("TOPPICCODE")
                    .HasMaxLength(10)
                    .ValueGeneratedNever();

                entity.Property(e => e.Attribute1)
                    .HasColumnName("ATTRIBUTE1")
                    .HasMaxLength(50);

                entity.Property(e => e.Attribute2)
                    .HasColumnName("ATTRIBUTE2")
                    .HasMaxLength(50);

                entity.Property(e => e.CreateDate)
                    .HasColumnName("CREATE_DATE")
                    .HasMaxLength(10);

                entity.Property(e => e.Description).HasColumnName("DESCRIPTION");

                entity.Property(e => e.Detail1).HasColumnName("DETAIL1");

                entity.Property(e => e.Detail2).HasColumnName("DETAIL2");

                entity.Property(e => e.Detail3).HasColumnName("DETAIL3");

                entity.Property(e => e.Image)
                    .HasColumnName("IMAGE")
                    .HasMaxLength(250);

                entity.Property(e => e.Index1)
                    .HasColumnName("INDEX1")
                    .HasMaxLength(250);

                entity.Property(e => e.Index2)
                    .HasColumnName("INDEX2")
                    .HasMaxLength(250);

                entity.Property(e => e.Index3)
                    .HasColumnName("INDEX3")
                    .HasMaxLength(250);

                entity.Property(e => e.Status)
                    .HasColumnName("STATUS")
                    .HasMaxLength(1);

                entity.Property(e => e.Title)
                    .HasColumnName("TITLE")
                    .HasMaxLength(250);

                entity.Property(e => e.Toppicname)
                    .HasColumnName("TOPPICNAME")
                    .HasMaxLength(50);

                entity.Property(e => e.UpDate)
                    .HasColumnName("UP_DATE")
                    .HasMaxLength(10);

                entity.Property(e => e.Votenumber)
                    .HasColumnName("VOTENUMBER")
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<MUntiltbl>(entity =>
            {
                entity.HasKey(e => e.Untilcode);

                entity.ToTable("M_UNTILTBL");

                entity.Property(e => e.Untilcode)
                    .HasColumnName("UNTILCODE")
                    .HasMaxLength(10)
                    .ValueGeneratedNever();

                entity.Property(e => e.Attribute1)
                    .HasColumnName("ATTRIBUTE1")
                    .HasMaxLength(50);

                entity.Property(e => e.Attribute2)
                    .HasColumnName("ATTRIBUTE2")
                    .HasMaxLength(50);

                entity.Property(e => e.CreateDate)
                    .HasColumnName("CREATE_DATE")
                    .HasMaxLength(10);

                entity.Property(e => e.Description).HasColumnName("DESCRIPTION");

                entity.Property(e => e.Status)
                    .HasColumnName("STATUS")
                    .HasMaxLength(1);

                entity.Property(e => e.Tblcode)
                    .HasColumnName("TBLCODE")
                    .HasMaxLength(10);

                entity.Property(e => e.Tblname)
                    .HasColumnName("TBLNAME")
                    .HasMaxLength(50);

                entity.Property(e => e.UpDate)
                    .HasColumnName("UP_DATE")
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<MUser>(entity =>
            {
                entity.HasKey(e => e.Usercode);

                entity.ToTable("M_USER");

                entity.Property(e => e.Usercode)
                    .HasColumnName("USERCODE")
                    .HasMaxLength(10)
                    .ValueGeneratedNever();

                entity.Property(e => e.Account)
                    .HasColumnName("ACCOUNT")
                    .HasMaxLength(50);

                entity.Property(e => e.Address)
                    .HasColumnName("ADDRESS")
                    .HasMaxLength(250);

                entity.Property(e => e.Attribute1)
                    .HasColumnName("ATTRIBUTE1")
                    .HasMaxLength(50);

                entity.Property(e => e.Attribute2)
                    .HasColumnName("ATTRIBUTE2")
                    .HasMaxLength(50);

                entity.Property(e => e.Authocode)
                    .HasColumnName("AUTHOCODE")
                    .HasMaxLength(10);

                entity.Property(e => e.Avatar)
                    .HasColumnName("AVATAR")
                    .HasMaxLength(250);

                entity.Property(e => e.CreateDate)
                    .HasColumnName("CREATE_DATE")
                    .HasMaxLength(10);

                entity.Property(e => e.Description).HasColumnName("DESCRIPTION");

                entity.Property(e => e.Email)
                    .HasColumnName("EMAIL")
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .HasColumnName("NAME")
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .HasColumnName("PASSWORD")
                    .HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .HasColumnName("PHONE")
                    .HasMaxLength(20);

                entity.Property(e => e.Sex)
                    .HasColumnName("SEX")
                    .HasMaxLength(1);

                entity.Property(e => e.Status)
                    .HasColumnName("STATUS")
                    .HasMaxLength(1);

                entity.Property(e => e.UpDate)
                    .HasColumnName("UP_DATE")
                    .HasMaxLength(10);
            });
        }
    }
}
