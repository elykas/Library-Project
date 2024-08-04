using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            Seed();
        }

        private void Seed()
        {
            if (!Library.Any())
            {
                List<LibraryModel> libraries = [
                    new(){
                        Genre = "Torah",
                        Shelfs = [
                            new()
                            {
                                Height = 0.5f,
                                Width = 1.2f,
                                SetBooks=[
                                    new(){
                                        Name = "Ramban",
                                        Books = [
                                            new(){
                                                Name= "Bereshit",
                                                Height = 0.25f,
                                                Width = 0.10f
                                            },
                                            new(){
                                                Name= "Shemot",
                                                Height = 0.25f,
                                                Width = 0.10f
                                            },
                                            new(){
                                                Name= "Vaikra",
                                                Height = 0.25f,
                                                Width = 0.10f
                                            },
                                            new(){
                                                Name= "Bamidbar",
                                                Height = 0.25f,
                                                Width = 0.10f
                                            }
                                            ],
                                    },
                                     new(){
                                        Name = "Or Hahaim",
                                        Books = [
                                            new(){
                                                Name= "Bereshit",
                                                Height = 0.18f,
                                                Width = 0.08f
                                            },
                                            new(){
                                                Name= "Shemot",
                                                 Height = 0.18f,
                                                 Width = 0.08f
                                            },
                                            new(){
                                                Name= "Vaikra",
                                                 Height = 0.18f,
                                                 Width = 0.08f
                                            },
                                            new(){
                                                Name= "Bamidbar",
                                                 Height = 0.18f,
                                                 Width = 0.08f
                                            }
                                            ]
                                     }

                                    ]
                            }

                            ]
                    }


                    ];
                Library.AddRange(libraries);
                SaveChanges();


            }
                    
        }

        public DbSet<LibraryModel> Library { get; set; }
        public DbSet<ShelfModel> Shelf { get; set; }
        public DbSet<SetBookModel> SetBooks { get; set; }
        public DbSet<BookModel> Book { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LibraryModel>()
                .HasMany(library => library.Shelfs)
                .WithOne(shelf => shelf.Library)
                .HasForeignKey(shelf => shelf.LibraryId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ShelfModel>()
                .HasMany(shelf => shelf.SetBooks)
                .WithOne(setBooks => setBooks.ShelfModel)
                .HasForeignKey(setBooks => setBooks.ShelfId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SetBookModel>()
               .HasMany(setBooks => setBooks.Books)
               .WithOne(books => books.SetBookModel)
               .HasForeignKey(books => books.SetBookId)
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
