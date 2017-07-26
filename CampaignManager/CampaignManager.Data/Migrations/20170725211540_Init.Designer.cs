using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CampaignManager.Data;
using CampaignManager.Data.Enums;

namespace CampaignManager.Data.Migrations
{
    [DbContext(typeof(CampaignContext))]
    [Migration("20170725211540_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CampaignManager.Data.Models.Ability", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .HasMaxLength(100);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Abilities");
                });

            modelBuilder.Entity("CampaignManager.Data.Models.Campaign", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Campaigns");
                });

            modelBuilder.Entity("CampaignManager.Data.Models.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<byte>("Alignment");

                    b.Property<int>("CampaignId");

                    b.Property<int>("Charisma");

                    b.Property<string>("Class")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("Constitution");

                    b.Property<int>("Dexterity");

                    b.Property<string>("Gender")
                        .HasMaxLength(50);

                    b.Property<string>("Height")
                        .HasMaxLength(10);

                    b.Property<int>("Intelligence");

                    b.Property<int>("Level");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Race")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<byte>("Size");

                    b.Property<int>("Strength");

                    b.Property<string>("Weight")
                        .HasMaxLength(10);

                    b.Property<int>("Wisdom");

                    b.HasKey("Id");

                    b.HasIndex("CampaignId");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("CampaignManager.Data.Models.CharacterAbility", b =>
                {
                    b.Property<int>("CharacterId");

                    b.Property<int>("AbilityId");

                    b.HasKey("CharacterId", "AbilityId");

                    b.HasIndex("AbilityId");

                    b.ToTable("CharacterAbility");
                });

            modelBuilder.Entity("CampaignManager.Data.Models.CharacterFeat", b =>
                {
                    b.Property<int>("CharacterId");

                    b.Property<int>("FeatId");

                    b.HasKey("CharacterId", "FeatId");

                    b.HasIndex("FeatId");

                    b.ToTable("CharacterFeat");
                });

            modelBuilder.Entity("CampaignManager.Data.Models.CharacterItem", b =>
                {
                    b.Property<int>("CharacterId");

                    b.Property<int>("ItemId");

                    b.HasKey("CharacterId", "ItemId");

                    b.HasIndex("ItemId");

                    b.ToTable("CharacterItem");
                });

            modelBuilder.Entity("CampaignManager.Data.Models.CharacterSkill", b =>
                {
                    b.Property<int>("CharacterId");

                    b.Property<int>("SkillId");

                    b.HasKey("CharacterId", "SkillId");

                    b.HasIndex("SkillId");

                    b.ToTable("CharacterSkill");
                });

            modelBuilder.Entity("CampaignManager.Data.Models.Feat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Feats");
                });

            modelBuilder.Entity("CampaignManager.Data.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .HasMaxLength(100);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Value")
                        .HasMaxLength(10);

                    b.Property<string>("Weight")
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("CampaignManager.Data.Models.Note", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CharacterId");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("CampaignManager.Data.Models.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("Ranks");

                    b.HasKey("Id");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("CampaignManager.Data.Models.Character", b =>
                {
                    b.HasOne("CampaignManager.Data.Models.Campaign", "Campaign")
                        .WithMany("Characters")
                        .HasForeignKey("CampaignId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CampaignManager.Data.Models.CharacterAbility", b =>
                {
                    b.HasOne("CampaignManager.Data.Models.Character", "Character")
                        .WithMany("CharacterAbilities")
                        .HasForeignKey("AbilityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CampaignManager.Data.Models.Ability", "Ability")
                        .WithMany("CharacterAbilities")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CampaignManager.Data.Models.CharacterFeat", b =>
                {
                    b.HasOne("CampaignManager.Data.Models.Feat", "Feat")
                        .WithMany("CharacterFeats")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CampaignManager.Data.Models.Character", "Character")
                        .WithMany("CharacterFeats")
                        .HasForeignKey("FeatId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CampaignManager.Data.Models.CharacterItem", b =>
                {
                    b.HasOne("CampaignManager.Data.Models.Item", "Item")
                        .WithMany("CharacterItems")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CampaignManager.Data.Models.Character", "Character")
                        .WithMany("CharacterItems")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CampaignManager.Data.Models.CharacterSkill", b =>
                {
                    b.HasOne("CampaignManager.Data.Models.Skill", "Skill")
                        .WithMany("CharacterSkills")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CampaignManager.Data.Models.Character", "Character")
                        .WithMany("CharacterSkills")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CampaignManager.Data.Models.Note", b =>
                {
                    b.HasOne("CampaignManager.Data.Models.Character", "Character")
                        .WithMany("Notes")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
