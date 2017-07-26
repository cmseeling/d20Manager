using CampaignManager.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CampaignManager.Data
{
    public class CampaignContext : DbContext
    {
        public CampaignContext(DbContextOptions<CampaignContext> options) : base(options)
        {
            //Database.EnsureCreated();
            Database.Migrate();
        }

        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<Character> Characters { get; set; }

        public DbSet<Ability> Abilities { get; set; }
        public DbSet<Feat> Feats { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Skill> Skills { get; set; }

        public DbSet<Note> Notes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CharacterAbility>()
                .HasKey(ca => new { ca.CharacterId, ca.AbilityId });

            modelBuilder.Entity<CharacterAbility>()
                .HasOne(ca => ca.Character)
                .WithMany(a => a.CharacterAbilities)
                .HasForeignKey(ca => ca.AbilityId);

            modelBuilder.Entity<CharacterAbility>()
                .HasOne(ca => ca.Ability)
                .WithMany(a => a.CharacterAbilities)
                .HasForeignKey(ca => ca.CharacterId);

            modelBuilder.Entity<CharacterFeat>()
                .HasKey(ca => new { ca.CharacterId, ca.FeatId });

            modelBuilder.Entity<CharacterFeat>()
                .HasOne(ca => ca.Character)
                .WithMany(a => a.CharacterFeats)
                .HasForeignKey(ca => ca.FeatId);

            modelBuilder.Entity<CharacterFeat>()
                .HasOne(ca => ca.Feat)
                .WithMany(a => a.CharacterFeats)
                .HasForeignKey(ca => ca.CharacterId);

            modelBuilder.Entity<CharacterItem>()
                .HasKey(ca => new { ca.CharacterId, ca.ItemId });

            modelBuilder.Entity<CharacterItem>()
                .HasOne(ca => ca.Character)
                .WithMany(a => a.CharacterItems)
                .HasForeignKey(ca => ca.ItemId);

            modelBuilder.Entity<CharacterItem>()
                .HasOne(ca => ca.Item)
                .WithMany(a => a.CharacterItems)
                .HasForeignKey(ca => ca.CharacterId);

            modelBuilder.Entity<CharacterSkill>()
                .HasKey(ca => new { ca.CharacterId, ca.SkillId });

            modelBuilder.Entity<CharacterSkill>()
                .HasOne(ca => ca.Character)
                .WithMany(a => a.CharacterSkills)
                .HasForeignKey(ca => ca.SkillId);

            modelBuilder.Entity<CharacterSkill>()
                .HasOne(ca => ca.Skill)
                .WithMany(a => a.CharacterSkills)
                .HasForeignKey(ca => ca.CharacterId);
        }
    }
}
