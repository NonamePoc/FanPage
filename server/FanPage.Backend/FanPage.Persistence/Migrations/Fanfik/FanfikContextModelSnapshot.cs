﻿// <auto-generated />
using System;
using FanPage.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FanPage.Persistence.Migrations.Fanfik
{
    [DbContext(typeof(FanfikContext))]
    partial class FanfikContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("FanPage.Domain.Entities.Fanfik.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CommentId"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("FanficId")
                        .HasColumnType("integer");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("CommentId");

                    b.HasIndex("FanficId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("FanPage.Domain.Entities.Fanfik.Fanfic", b =>
                {
                    b.Property<int>("FanficId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("FanficId"));

                    b.Property<string>("AuthorId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("OriginFandom")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Rating")
                        .HasColumnType("double precision");

                    b.Property<string>("Tag")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("FanficId");

                    b.HasIndex("AuthorId");

                    b.ToTable("Fanfics");
                });

            modelBuilder.Entity("FanPage.Domain.Entities.Fanfik.Like", b =>
                {
                    b.Property<int>("LikeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("LikeId"));

                    b.Property<int>("FanficId")
                        .HasColumnType("integer");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LikeId");

                    b.HasIndex("FanficId");

                    b.HasIndex("UserId");

                    b.ToTable("Likes");
                });

            modelBuilder.Entity("FanPage.Domain.Entities.Fanfik.PaymentMethod", b =>
                {
                    b.Property<int>("PaymentMethodId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PaymentMethodId"));

                    b.Property<string>("CVV")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CardNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("FanficId")
                        .HasColumnType("integer");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("PaymentMethodId");

                    b.HasIndex("FanficId");

                    b.HasIndex("UserId");

                    b.ToTable("PaymentMethods");
                });

            modelBuilder.Entity("FanPage.Domain.Entities.Identity.Bookmark", b =>
                {
                    b.Property<int>("BookmarkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("BookmarkId"));

                    b.Property<int>("FanficId")
                        .HasColumnType("integer");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("BookmarkId");

                    b.HasIndex("FanficId");

                    b.HasIndex("UserId");

                    b.ToTable("Bookmark");
                });

            modelBuilder.Entity("FanPage.Domain.Entities.Identity.CustomizationSettings", b =>
                {
                    b.Property<int>("CustomizationSettingsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CustomizationSettingsId"));

                    b.Property<string>("BannerUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("CustomizationSettingsId");

                    b.ToTable("CustomizationSettings");
                });

            modelBuilder.Entity("FanPage.Domain.Entities.Identity.Follower", b =>
                {
                    b.Property<int>("FollowerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("FollowerId"));

                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.HasKey("FollowerId");

                    b.HasIndex("UserId");

                    b.ToTable("Follower");
                });

            modelBuilder.Entity("FanPage.Domain.Entities.Identity.Friendship", b =>
                {
                    b.Property<int>("FriendshipId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("FriendshipId"));

                    b.Property<string>("FriendId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("FriendshipId");

                    b.HasIndex("FriendId");

                    b.HasIndex("UserId");

                    b.ToTable("Friendship");
                });

            modelBuilder.Entity("FanPage.Domain.Entities.Identity.Sticker", b =>
                {
                    b.Property<int>("StickerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("StickerId"));

                    b.Property<int>("CustomizationSettingsId")
                        .HasColumnType("integer");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("StickerId");

                    b.HasIndex("CustomizationSettingsId");

                    b.ToTable("Sticker");
                });

            modelBuilder.Entity("FanPage.Domain.Entities.Identity.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("text");

                    b.Property<int>("CustomizationSettingsId")
                        .HasColumnType("integer");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("text");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("ProfilePictureUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CustomizationSettingsId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("FanPage.Domain.Entities.Fanfik.Comment", b =>
                {
                    b.HasOne("FanPage.Domain.Entities.Fanfik.Fanfic", "Fanfic")
                        .WithMany("Comments")
                        .HasForeignKey("FanficId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FanPage.Domain.Entities.Identity.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fanfic");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FanPage.Domain.Entities.Fanfik.Fanfic", b =>
                {
                    b.HasOne("FanPage.Domain.Entities.Identity.User", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("FanPage.Domain.Entities.Fanfik.Like", b =>
                {
                    b.HasOne("FanPage.Domain.Entities.Fanfik.Fanfic", "Fanfic")
                        .WithMany("Likes")
                        .HasForeignKey("FanficId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FanPage.Domain.Entities.Identity.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fanfic");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FanPage.Domain.Entities.Fanfik.PaymentMethod", b =>
                {
                    b.HasOne("FanPage.Domain.Entities.Fanfik.Fanfic", null)
                        .WithMany("PaymentMethods")
                        .HasForeignKey("FanficId");

                    b.HasOne("FanPage.Domain.Entities.Identity.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("FanPage.Domain.Entities.Identity.Bookmark", b =>
                {
                    b.HasOne("FanPage.Domain.Entities.Fanfik.Fanfic", "Fanfic")
                        .WithMany("Bookmarks")
                        .HasForeignKey("FanficId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FanPage.Domain.Entities.Identity.User", "User")
                        .WithMany("Bookmarks")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fanfic");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FanPage.Domain.Entities.Identity.Follower", b =>
                {
                    b.HasOne("FanPage.Domain.Entities.Identity.User", "User")
                        .WithMany("Followers")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FanPage.Domain.Entities.Identity.Friendship", b =>
                {
                    b.HasOne("FanPage.Domain.Entities.Identity.User", "Friend")
                        .WithMany("FriendsOfMine")
                        .HasForeignKey("FriendId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FanPage.Domain.Entities.Identity.User", "User")
                        .WithMany("MyFriends")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Friend");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FanPage.Domain.Entities.Identity.Sticker", b =>
                {
                    b.HasOne("FanPage.Domain.Entities.Identity.CustomizationSettings", "CustomizationSettings")
                        .WithMany("CustomStickers")
                        .HasForeignKey("CustomizationSettingsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CustomizationSettings");
                });

            modelBuilder.Entity("FanPage.Domain.Entities.Identity.User", b =>
                {
                    b.HasOne("FanPage.Domain.Entities.Identity.CustomizationSettings", "CustomizationSettings")
                        .WithMany()
                        .HasForeignKey("CustomizationSettingsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CustomizationSettings");
                });

            modelBuilder.Entity("FanPage.Domain.Entities.Fanfik.Fanfic", b =>
                {
                    b.Navigation("Bookmarks");

                    b.Navigation("Comments");

                    b.Navigation("Likes");

                    b.Navigation("PaymentMethods");
                });

            modelBuilder.Entity("FanPage.Domain.Entities.Identity.CustomizationSettings", b =>
                {
                    b.Navigation("CustomStickers");
                });

            modelBuilder.Entity("FanPage.Domain.Entities.Identity.User", b =>
                {
                    b.Navigation("Bookmarks");

                    b.Navigation("Followers");

                    b.Navigation("FriendsOfMine");

                    b.Navigation("MyFriends");
                });
#pragma warning restore 612, 618
        }
    }
}