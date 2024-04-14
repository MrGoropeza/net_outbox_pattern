using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Persistence.Models;

namespace Persistence;

public partial class OutboxDbContext : DbContext
{
    public OutboxDbContext(DbContextOptions<OutboxDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Alarm> Alarms { get; set; }

    public virtual DbSet<AlarmItem> AlarmItems { get; set; }

    public virtual DbSet<AlarmNotificationType> AlarmNotificationTypes { get; set; }

    public virtual DbSet<AlarmType> AlarmTypes { get; set; }

    public virtual DbSet<Allergy> Allergies { get; set; }

    public virtual DbSet<BloodFactor> BloodFactors { get; set; }

    public virtual DbSet<BloodType> BloodTypes { get; set; }

    public virtual DbSet<CodeType> CodeTypes { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Diagnostic> Diagnostics { get; set; }

    public virtual DbSet<Disease> Diseases { get; set; }

    public virtual DbSet<Document> Documents { get; set; }

    public virtual DbSet<FamilyPathology> FamilyPathologies { get; set; }

    public virtual DbSet<FamilyType> FamilyTypes { get; set; }

    public virtual DbSet<Folder> Folders { get; set; }

    public virtual DbSet<Gender> Genders { get; set; }

    public virtual DbSet<HealthInsurance> HealthInsurances { get; set; }

    public virtual DbSet<HealthMetric> HealthMetrics { get; set; }

    public virtual DbSet<HealthMetricUnit> HealthMetricUnits { get; set; }

    public virtual DbSet<HealthTip> HealthTips { get; set; }

    public virtual DbSet<Interest> Interests { get; set; }

    public virtual DbSet<Locality> Localities { get; set; }

    public virtual DbSet<MedicenterFile> MedicenterFiles { get; set; }

    public virtual DbSet<Medicine> Medicines { get; set; }

    public virtual DbSet<OutboxMessage> OutboxMessages { get; set; }

    public virtual DbSet<PostShareType> PostShareTypes { get; set; }

    public virtual DbSet<PostType> PostTypes { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<State> States { get; set; }

    public virtual DbSet<Step> Steps { get; set; }

    public virtual DbSet<ToxicHabit> ToxicHabits { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserHealthMetric> UserHealthMetrics { get; set; }

    public virtual DbSet<UserInterest> UserInterests { get; set; }

    public virtual DbSet<UserMedicine> UserMedicines { get; set; }

    public virtual DbSet<UserPathology> UserPathologies { get; set; }

    public virtual DbSet<UserPost> UserPosts { get; set; }

    public virtual DbSet<UserProfile> UserProfiles { get; set; }

    public virtual DbSet<UserRecoveryCode> UserRecoveryCodes { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    public virtual DbSet<UserStep> UserSteps { get; set; }

    public virtual DbSet<Weekday> Weekdays { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Alarm>(entity =>
        {
            entity.HasKey(e => e.AlarmId).HasName("alarms_pkey");

            entity.ToTable("alarms");

            entity.Property(e => e.AlarmId)
                .HasDefaultValueSql("nextval('alarms_alarm_id_seq1'::regclass)")
                .HasColumnName("alarm_id");
            entity.Property(e => e.AlarmTypeId).HasColumnName("alarm_type_id");
            entity.Property(e => e.AppointmentAddress).HasColumnName("appointment_address");
            entity.Property(e => e.AppointmentComment).HasColumnName("appointment_comment");
            entity.Property(e => e.AppointmentLat).HasColumnName("appointment_lat");
            entity.Property(e => e.AppointmentLong).HasColumnName("appointment_long");
            entity.Property(e => e.AppointmentReason).HasColumnName("appointment_reason");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.IsEnabled)
                .HasDefaultValue(true)
                .HasColumnName("is_enabled");
            entity.Property(e => e.MedicineId).HasColumnName("medicine_id");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
            entity.Property(e => e.UserProfileId).HasColumnName("user_profile_id");

            entity.HasOne(d => d.AlarmType).WithMany(p => p.Alarms)
                .HasForeignKey(d => d.AlarmTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("alarms_alarm_types_fk");

            entity.HasOne(d => d.Medicine).WithMany(p => p.Alarms)
                .HasForeignKey(d => d.MedicineId)
                .HasConstraintName("alarms_medicines_fk");

            entity.HasOne(d => d.UserProfile).WithMany(p => p.Alarms)
                .HasForeignKey(d => d.UserProfileId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("alarms_user_profiles_fk");
        });

        modelBuilder.Entity<AlarmItem>(entity =>
        {
            entity.HasKey(e => e.AlarmItemId).HasName("alarm_items_pkey");

            entity.ToTable("alarm_items");

            entity.Property(e => e.AlarmItemId)
                .HasDefaultValueSql("nextval('alarm_items_alarm_item_id_seq1'::regclass)")
                .HasColumnName("alarm_item_id");
            entity.Property(e => e.AlarmId).HasColumnName("alarm_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.Time)
                .HasColumnType("time with time zone")
                .HasColumnName("time");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
            entity.Property(e => e.WeekdayId).HasColumnName("weekday_id");

            entity.HasOne(d => d.Alarm).WithMany(p => p.AlarmItems)
                .HasForeignKey(d => d.AlarmId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("alarm_items_alarms_dk");

            entity.HasOne(d => d.Weekday).WithMany(p => p.AlarmItems)
                .HasForeignKey(d => d.WeekdayId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("alarm_items_weekdays_fk");
        });

        modelBuilder.Entity<AlarmNotificationType>(entity =>
        {
            entity.HasKey(e => e.AlarmNotificationTypeId).HasName("alarm_notification_type_pkey");

            entity.ToTable("alarm_notification_type");

            entity.Property(e => e.AlarmNotificationTypeId)
                .HasDefaultValueSql("nextval('alarm_notification_type_alarm_notification_type_id_seq1'::regclass)")
                .HasColumnName("alarm_notification_type_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
        });

        modelBuilder.Entity<AlarmType>(entity =>
        {
            entity.HasKey(e => e.AlarmTypeId).HasName("alarm_types_pkey");

            entity.ToTable("alarm_types");

            entity.Property(e => e.AlarmTypeId)
                .HasDefaultValueSql("nextval('alarm_types_alarm_type_id_seq1'::regclass)")
                .HasColumnName("alarm_type_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
        });

        modelBuilder.Entity<Allergy>(entity =>
        {
            entity.HasKey(e => e.AllergyId).HasName("allergies_pkey");

            entity.ToTable("allergies");

            entity.Property(e => e.AllergyId)
                .HasDefaultValueSql("nextval('allergies_allergy_id_seq1'::regclass)")
                .HasColumnName("allergy_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.IcdCode).HasColumnName("icd_code");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
        });

        modelBuilder.Entity<BloodFactor>(entity =>
        {
            entity.HasKey(e => e.BloodFactorId).HasName("blood_factors_pkey");

            entity.ToTable("blood_factors");

            entity.Property(e => e.BloodFactorId)
                .HasDefaultValueSql("nextval('blood_factors_blood_factor_id_seq1'::regclass)")
                .HasColumnName("blood_factor_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
        });

        modelBuilder.Entity<BloodType>(entity =>
        {
            entity.HasKey(e => e.BloodTypeId).HasName("blood_types_pkey");

            entity.ToTable("blood_types");

            entity.Property(e => e.BloodTypeId)
                .HasDefaultValueSql("nextval('blood_types_blood_type_id_seq1'::regclass)")
                .HasColumnName("blood_type_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
        });

        modelBuilder.Entity<CodeType>(entity =>
        {
            entity.HasKey(e => e.CodeTypeId).HasName("code_types_pkey");

            entity.ToTable("code_types");

            entity.Property(e => e.CodeTypeId)
                .HasDefaultValueSql("nextval('code_types_code_type_id_seq1'::regclass)")
                .HasColumnName("code_type_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("timezone('utc'::text, now())")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("timezone('utc'::text, now())")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.CountryId).HasName("countries_pkey");

            entity.ToTable("countries");

            entity.Property(e => e.CountryId)
                .HasDefaultValueSql("nextval('countries_country_id_seq1'::regclass)")
                .HasColumnName("country_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.PhoneCode).HasColumnName("phone_code");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
        });

        modelBuilder.Entity<Diagnostic>(entity =>
        {
            entity.HasKey(e => e.DiagnosticId).HasName("diagnostics_pkey");

            entity.ToTable("diagnostics");

            entity.Property(e => e.DiagnosticId)
                .HasDefaultValueSql("nextval('diagnostics_daignostic_id_seq'::regclass)")
                .HasColumnName("diagnostic_id");
            entity.Property(e => e.Comment).HasColumnName("comment");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("timezone('utc'::text, now())")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatorName)
                .HasColumnType("character varying")
                .HasColumnName("creator_name");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("timezone('utc'::text, now())")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
            entity.Property(e => e.UserPostId).HasColumnName("user_post_id");

            entity.HasOne(d => d.UserPost).WithMany(p => p.Diagnostics)
                .HasForeignKey(d => d.UserPostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("diagnostics_user_posts_fk");
        });

        modelBuilder.Entity<Disease>(entity =>
        {
            entity.HasKey(e => e.DiseaseId).HasName("diseases_pkey");

            entity.ToTable("diseases");

            entity.Property(e => e.DiseaseId)
                .HasDefaultValueSql("nextval('diseases_disease_id_seq1'::regclass)")
                .HasColumnName("disease_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.IcdCode).HasColumnName("icd_code");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
        });

        modelBuilder.Entity<Document>(entity =>
        {
            entity.HasKey(e => e.DocumentId).HasName("documents_pkey");

            entity.ToTable("documents");

            entity.Property(e => e.DocumentId)
                .HasDefaultValueSql("nextval('documents_document_id_seq1'::regclass)")
                .HasColumnName("document_id");
            entity.Property(e => e.AllergyId).HasColumnName("allergy_id");
            entity.Property(e => e.Comment).HasColumnName("comment");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.DiseaseId).HasColumnName("disease_id");
            entity.Property(e => e.FolderId).HasColumnName("folder_id");
            entity.Property(e => e.IsFeatured)
                .HasDefaultValue(false)
                .HasColumnName("is_featured");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.StudyDate).HasColumnName("study_date");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            entity.HasOne(d => d.Allergy).WithMany(p => p.Documents)
                .HasForeignKey(d => d.AllergyId)
                .HasConstraintName("documents_allergies_fk");

            entity.HasOne(d => d.Disease).WithMany(p => p.Documents)
                .HasForeignKey(d => d.DiseaseId)
                .HasConstraintName("documents_diseases_fk");

            entity.HasOne(d => d.Folder).WithMany(p => p.Documents)
                .HasForeignKey(d => d.FolderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("documents_folders_fk");
        });

        modelBuilder.Entity<FamilyPathology>(entity =>
        {
            entity.HasKey(e => e.FamilyPathologyId).HasName("family_pathologies_pkey");

            entity.ToTable("family_pathologies");

            entity.Property(e => e.FamilyPathologyId)
                .HasDefaultValueSql("nextval('family_pathologies_family_pathology_id_seq1'::regclass)")
                .HasColumnName("family_pathology_id");
            entity.Property(e => e.AllergyId).HasColumnName("allergy_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.DiagnosisEndDate).HasColumnName("diagnosis_end_date");
            entity.Property(e => e.DiagnosisInitialDate).HasColumnName("diagnosis_initial_date");
            entity.Property(e => e.DiseaseId).HasColumnName("disease_id");
            entity.Property(e => e.FamilyTypeId).HasColumnName("family_type_id");
            entity.Property(e => e.IsCurrentDiagnosis)
                .HasDefaultValue(false)
                .HasColumnName("is_current_diagnosis");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
            entity.Property(e => e.UserProfileId).HasColumnName("user_profile_id");

            entity.HasOne(d => d.Allergy).WithMany(p => p.FamilyPathologies)
                .HasForeignKey(d => d.AllergyId)
                .HasConstraintName("family_pathologies_allergies_fk");

            entity.HasOne(d => d.Disease).WithMany(p => p.FamilyPathologies)
                .HasForeignKey(d => d.DiseaseId)
                .HasConstraintName("family_pathologies_diseases_fk");

            entity.HasOne(d => d.FamilyType).WithMany(p => p.FamilyPathologies)
                .HasForeignKey(d => d.FamilyTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("family_pathologies_family_types_fk");

            entity.HasOne(d => d.UserProfile).WithMany(p => p.FamilyPathologies)
                .HasForeignKey(d => d.UserProfileId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("family_pathologies_user_profiles_fk");
        });

        modelBuilder.Entity<FamilyType>(entity =>
        {
            entity.HasKey(e => e.FamilyTypeId).HasName("family_types_pkey");

            entity.ToTable("family_types");

            entity.Property(e => e.FamilyTypeId)
                .HasDefaultValueSql("nextval('family_types_family_type_id_seq1'::regclass)")
                .HasColumnName("family_type_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
        });

        modelBuilder.Entity<Folder>(entity =>
        {
            entity.HasKey(e => e.FolderId).HasName("folders_pkey");

            entity.ToTable("folders");

            entity.Property(e => e.FolderId)
                .HasDefaultValueSql("nextval('folders_folder_id_seq1'::regclass)")
                .HasColumnName("folder_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
            entity.Property(e => e.UserProfileId).HasColumnName("user_profile_id");

            entity.HasOne(d => d.UserProfile).WithMany(p => p.Folders)
                .HasForeignKey(d => d.UserProfileId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("folders_user_profiles_fk");
        });

        modelBuilder.Entity<Gender>(entity =>
        {
            entity.HasKey(e => e.GenderId).HasName("genders_pkey");

            entity.ToTable("genders");

            entity.Property(e => e.GenderId)
                .HasDefaultValueSql("nextval('genders_gender_id_seq1'::regclass)")
                .HasColumnName("gender_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
        });

        modelBuilder.Entity<HealthInsurance>(entity =>
        {
            entity.HasKey(e => e.HealthInsuranceId).HasName("health_insurances_pkey");

            entity.ToTable("health_insurances");

            entity.Property(e => e.HealthInsuranceId)
                .HasDefaultValueSql("nextval('health_insurances_health_insurance_id_seq1'::regclass)")
                .HasColumnName("health_insurance_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
        });

        modelBuilder.Entity<HealthMetric>(entity =>
        {
            entity.HasKey(e => e.HealthMetricId).HasName("health_metrics_pkey");

            entity.ToTable("health_metrics");

            entity.Property(e => e.HealthMetricId)
                .HasDefaultValueSql("nextval('health_metrics_health_metric_id_seq1'::regclass)")
                .HasColumnName("health_metric_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
        });

        modelBuilder.Entity<HealthMetricUnit>(entity =>
        {
            entity.HasKey(e => e.HealthMetricUnitId).HasName("health_metric_units_pkey");

            entity.ToTable("health_metric_units");

            entity.Property(e => e.HealthMetricUnitId)
                .HasDefaultValueSql("nextval('health_metric_units_health_metric_unit_id_seq1'::regclass)")
                .HasColumnName("health_metric_unit_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
        });

        modelBuilder.Entity<HealthTip>(entity =>
        {
            entity.HasKey(e => e.HealthTipId).HasName("health_tips_pkey");

            entity.ToTable("health_tips");

            entity.Property(e => e.HealthTipId)
                .HasDefaultValueSql("nextval('health_tips_health_tip_id_seq1'::regclass)")
                .HasColumnName("health_tip_id");
            entity.Property(e => e.Content).HasColumnName("content");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.InterestId).HasColumnName("interest_id");
            entity.Property(e => e.Title).HasColumnName("title");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            entity.HasOne(d => d.Interest).WithMany(p => p.HealthTips)
                .HasForeignKey(d => d.InterestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("health_tips_interests_fk");
        });

        modelBuilder.Entity<Interest>(entity =>
        {
            entity.HasKey(e => e.InterestId).HasName("interests_pkey");

            entity.ToTable("interests");

            entity.Property(e => e.InterestId)
                .HasDefaultValueSql("nextval('interests_interest_id_seq1'::regclass)")
                .HasColumnName("interest_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.FileId).HasColumnName("file_id");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            entity.HasOne(d => d.File).WithMany(p => p.Interests)
                .HasForeignKey(d => d.FileId)
                .HasConstraintName("interests_files_fk");
        });

        modelBuilder.Entity<Locality>(entity =>
        {
            entity.HasKey(e => e.LocalityId).HasName("localities_pkey");

            entity.ToTable("localities");

            entity.Property(e => e.LocalityId)
                .HasDefaultValueSql("nextval('localities_locality_id_seq1'::regclass)")
                .HasColumnName("locality_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.StateId).HasColumnName("state_id");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            entity.HasOne(d => d.State).WithMany(p => p.Localities)
                .HasForeignKey(d => d.StateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("localities_states_fk");
        });

        modelBuilder.Entity<MedicenterFile>(entity =>
        {
            entity.HasKey(e => e.FileId).HasName("files_pkey");

            entity.ToTable("medicenter_files");

            entity.Property(e => e.FileId)
                .HasDefaultValueSql("nextval('files_file_id_seq'::regclass)")
                .HasColumnName("file_id");
            entity.Property(e => e.CdnFileName)
                .HasColumnType("character varying")
                .HasColumnName("cdn_file_name");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.DocumentId).HasColumnName("document_id");
            entity.Property(e => e.FileName).HasColumnName("file_name");
            entity.Property(e => e.FileSize).HasColumnName("file_size");
            entity.Property(e => e.MimeType).HasColumnName("mime_type");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            entity.HasOne(d => d.Document).WithMany(p => p.MedicenterFiles)
                .HasForeignKey(d => d.DocumentId)
                .HasConstraintName("medicenter_files_documents_fk");
        });

        modelBuilder.Entity<Medicine>(entity =>
        {
            entity.HasKey(e => e.MedicineId).HasName("medicines_pkey");

            entity.ToTable("medicines");

            entity.Property(e => e.MedicineId)
                .HasDefaultValueSql("nextval('medicines_medicine_id_seq1'::regclass)")
                .HasColumnName("medicine_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
        });

        modelBuilder.Entity<OutboxMessage>(entity =>
        {
            entity.HasKey(e => e.OutboxMessageId).HasName("outbox_messages_pkey");

            entity.ToTable("outbox_messages");

            entity.Property(e => e.OutboxMessageId).HasColumnName("outbox_message_id");
            entity.Property(e => e.Content).HasColumnName("content");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.Error).HasColumnName("error");
            entity.Property(e => e.ProcessedAt).HasColumnName("processed_at");
            entity.Property(e => e.Type).HasColumnName("type");
        });

        modelBuilder.Entity<PostShareType>(entity =>
        {
            entity.HasKey(e => e.PostShareTypeId).HasName("post_share_types_pkey");

            entity.ToTable("post_share_types");

            entity.Property(e => e.PostShareTypeId)
                .HasDefaultValueSql("nextval('post_share_types_post_share_type_id_seq1'::regclass)")
                .HasColumnName("post_share_type_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
        });

        modelBuilder.Entity<PostType>(entity =>
        {
            entity.HasKey(e => e.PostTypeId).HasName("post_types_pkey");

            entity.ToTable("post_types");

            entity.Property(e => e.PostTypeId)
                .HasDefaultValueSql("nextval('post_types_post_type_id_seq1'::regclass)")
                .HasColumnName("post_type_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("roles_pkey");

            entity.ToTable("roles");

            entity.Property(e => e.RoleId)
                .HasDefaultValueSql("nextval('roles_role_id_seq1'::regclass)")
                .HasColumnName("role_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
        });

        modelBuilder.Entity<State>(entity =>
        {
            entity.HasKey(e => e.StateId).HasName("states_pkey");

            entity.ToTable("states");

            entity.Property(e => e.StateId)
                .HasDefaultValueSql("nextval('states_state_id_seq1'::regclass)")
                .HasColumnName("state_id");
            entity.Property(e => e.CountryId).HasColumnName("country_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            entity.HasOne(d => d.Country).WithMany(p => p.States)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("states_countries_fk");
        });

        modelBuilder.Entity<Step>(entity =>
        {
            entity.HasKey(e => e.StepId).HasName("steps_pkey");

            entity.ToTable("steps");

            entity.Property(e => e.StepId)
                .HasDefaultValueSql("nextval('steps_steps_id_seq'::regclass)")
                .HasColumnName("step_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("timezone('utc'::text, now())")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("timezone('utc'::text, now())")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
        });

        modelBuilder.Entity<ToxicHabit>(entity =>
        {
            entity.HasKey(e => e.ToxicHabitId).HasName("toxic_habits_pkey");

            entity.ToTable("toxic_habits");

            entity.HasIndex(e => e.UserProfileId, "toxic_habits_user_profile_id_unq").IsUnique();

            entity.Property(e => e.ToxicHabitId)
                .HasDefaultValueSql("nextval('toxic_habits_toxic_habit_id_seq1'::regclass)")
                .HasColumnName("toxic_habit_id");
            entity.Property(e => e.Alcoholism).HasColumnName("alcoholism");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.DrugAddiction).HasColumnName("drug_addiction");
            entity.Property(e => e.Smoking).HasColumnName("smoking");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
            entity.Property(e => e.UserProfileId).HasColumnName("user_profile_id");

            entity.HasOne(d => d.UserProfile).WithOne(p => p.ToxicHabit)
                .HasForeignKey<ToxicHabit>(d => d.UserProfileId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("toxic_habits_user_profiles_fk");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("users_pkey");

            entity.ToTable("users");

            entity.Property(e => e.UserId)
                .HasDefaultValueSql("nextval('users_user_id_seq1'::regclass)")
                .HasColumnName("user_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.Hash).HasColumnName("hash");
            entity.Property(e => e.IsVerified)
                .HasDefaultValue(false)
                .HasColumnName("is_verified");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
            entity.Property(e => e.UserName).HasColumnName("user_name");
        });

        modelBuilder.Entity<UserHealthMetric>(entity =>
        {
            entity.HasKey(e => e.UserHealthMetricId).HasName("user_health_metrics_pkey");

            entity.ToTable("user_health_metrics");

            entity.Property(e => e.UserHealthMetricId)
                .HasDefaultValueSql("nextval('user_health_metrics_user_health_metric_id_seq1'::regclass)")
                .HasColumnName("user_health_metric_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.HealthMetricId).HasColumnName("health_metric_id");
            entity.Property(e => e.HealthMetricUnitId).HasColumnName("health_metric_unit_id");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
            entity.Property(e => e.UserProfileId).HasColumnName("user_profile_id");
            entity.Property(e => e.Value).HasColumnName("value");
            entity.Property(e => e.Value2).HasColumnName("value2");

            entity.HasOne(d => d.HealthMetric).WithMany(p => p.UserHealthMetrics)
                .HasForeignKey(d => d.HealthMetricId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("user_health_metrics_health_metrics_fk");

            entity.HasOne(d => d.HealthMetricUnit).WithMany(p => p.UserHealthMetrics)
                .HasForeignKey(d => d.HealthMetricUnitId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("user_health_metrics_health_metric_units_fk");

            entity.HasOne(d => d.UserProfile).WithMany(p => p.UserHealthMetrics)
                .HasForeignKey(d => d.UserProfileId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("user_health_metrics_user_profiles_fk");
        });

        modelBuilder.Entity<UserInterest>(entity =>
        {
            entity.HasKey(e => e.UserInterestId).HasName("user_interests_pkey");

            entity.ToTable("user_interests");

            entity.Property(e => e.UserInterestId)
                .HasDefaultValueSql("nextval('user_interests_user_interest_id_seq1'::regclass)")
                .HasColumnName("user_interest_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.InterestId).HasColumnName("interest_id");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
            entity.Property(e => e.UserProfileId).HasColumnName("user_profile_id");

            entity.HasOne(d => d.Interest).WithMany(p => p.UserInterests)
                .HasForeignKey(d => d.InterestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("user_interests_interests_fk");

            entity.HasOne(d => d.UserProfile).WithMany(p => p.UserInterests)
                .HasForeignKey(d => d.UserProfileId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("user_interests_user_profiles_fk");
        });

        modelBuilder.Entity<UserMedicine>(entity =>
        {
            entity.HasKey(e => e.UserMedicineId).HasName("user_medicines_pkey");

            entity.ToTable("user_medicines");

            entity.Property(e => e.UserMedicineId)
                .HasDefaultValueSql("nextval('user_medicines_user_medicine_id_seq1'::regclass)")
                .HasColumnName("user_medicine_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.MedicineId).HasColumnName("medicine_id");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
            entity.Property(e => e.UserProfileId).HasColumnName("user_profile_id");

            entity.HasOne(d => d.Medicine).WithMany(p => p.UserMedicines)
                .HasForeignKey(d => d.MedicineId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("user_medicines_medicines_fk");

            entity.HasOne(d => d.UserProfile).WithMany(p => p.UserMedicines)
                .HasForeignKey(d => d.UserProfileId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("user_medicines_user_profiles_fk");
        });

        modelBuilder.Entity<UserPathology>(entity =>
        {
            entity.HasKey(e => e.UserPathologyId).HasName("user_pathologies_pkey");

            entity.ToTable("user_pathologies");

            entity.Property(e => e.UserPathologyId)
                .HasDefaultValueSql("nextval('user_pathologies_user_pathology_id_seq1'::regclass)")
                .HasColumnName("user_pathology_id");
            entity.Property(e => e.AllergyId).HasColumnName("allergy_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.DiagnosisEndDate).HasColumnName("diagnosis_end_date");
            entity.Property(e => e.DiagnosisInitialDate).HasColumnName("diagnosis_initial_date");
            entity.Property(e => e.DiseaseId).HasColumnName("disease_id");
            entity.Property(e => e.IsCurrentDiagnosis)
                .HasDefaultValue(false)
                .HasColumnName("is_current_diagnosis");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
            entity.Property(e => e.UserProfileId).HasColumnName("user_profile_id");

            entity.HasOne(d => d.Allergy).WithMany(p => p.UserPathologies)
                .HasForeignKey(d => d.AllergyId)
                .HasConstraintName("user_pathologies_allergies_fk");

            entity.HasOne(d => d.Disease).WithMany(p => p.UserPathologies)
                .HasForeignKey(d => d.DiseaseId)
                .HasConstraintName("user_pathologies_diseases_fk");

            entity.HasOne(d => d.UserProfile).WithMany(p => p.UserPathologies)
                .HasForeignKey(d => d.UserProfileId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("user_pathologies_user_profiles_fk");
        });

        modelBuilder.Entity<UserPost>(entity =>
        {
            entity.HasKey(e => e.UserPostId).HasName("user_posts_pkey");

            entity.ToTable("user_posts");

            entity.HasIndex(e => e.PostUuid, "user_posts_unique").IsUnique();

            entity.Property(e => e.UserPostId)
                .HasDefaultValueSql("nextval('user_posts_user_post_id_seq1'::regclass)")
                .HasColumnName("user_post_id");
            entity.Property(e => e.Comment).HasColumnName("comment");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("timezone('utc'::text, now())")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.DocumentId).HasColumnName("document_id");
            entity.Property(e => e.FolderId).HasColumnName("folder_id");
            entity.Property(e => e.HealthMetricId).HasColumnName("health_metric_id");
            entity.Property(e => e.IsEnabled)
                .HasDefaultValue(true)
                .HasColumnName("is_enabled");
            entity.Property(e => e.LastSeen).HasColumnName("last_seen");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.PostShareTypeId).HasColumnName("post_share_type_id");
            entity.Property(e => e.PostTypeId).HasColumnName("post_type_id");
            entity.Property(e => e.PostUuid).HasColumnName("post_uuid");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("timezone('utc'::text, now())")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
            entity.Property(e => e.UserProfileId).HasColumnName("user_profile_id");
            entity.Property(e => e.Views)
                .HasDefaultValue(0L)
                .HasColumnName("views");

            entity.HasOne(d => d.Document).WithMany(p => p.UserPosts)
                .HasForeignKey(d => d.DocumentId)
                .HasConstraintName("user_posts_documents_fk");

            entity.HasOne(d => d.Folder).WithMany(p => p.UserPosts)
                .HasForeignKey(d => d.FolderId)
                .HasConstraintName("user_posts_folders_fk");

            entity.HasOne(d => d.PostShareType).WithMany(p => p.UserPosts)
                .HasForeignKey(d => d.PostShareTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("user_posts_post_share_types_fk");

            entity.HasOne(d => d.PostType).WithMany(p => p.UserPosts)
                .HasForeignKey(d => d.PostTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("user_posts_post_types_fk");

            entity.HasOne(d => d.UserProfile).WithMany(p => p.UserPosts)
                .HasForeignKey(d => d.UserProfileId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("user_posts_user_profiles_fk");
        });

        modelBuilder.Entity<UserProfile>(entity =>
        {
            entity.HasKey(e => e.UserProfileId).HasName("user_profiles_pkey");

            entity.ToTable("user_profiles");

            entity.HasIndex(e => e.UserId, "user_profiles_user_id_unq").IsUnique();

            entity.Property(e => e.UserProfileId)
                .HasDefaultValueSql("nextval('user_profiles_user_profile_id_seq1'::regclass)")
                .HasColumnName("user_profile_id");
            entity.Property(e => e.BirthDate).HasColumnName("birth_date");
            entity.Property(e => e.BirthplaceCountryId).HasColumnName("birthplace_country_id");
            entity.Property(e => e.BirthplaceLocalityId).HasColumnName("birthplace_locality_id");
            entity.Property(e => e.BirthplaceStateId).HasColumnName("birthplace_state_id");
            entity.Property(e => e.BloodFactorId).HasColumnName("blood_factor_id");
            entity.Property(e => e.BloodTypeId).HasColumnName("blood_type_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.FileId).HasColumnName("file_id");
            entity.Property(e => e.FirstName).HasColumnName("first_name");
            entity.Property(e => e.GenderId).HasColumnName("gender_id");
            entity.Property(e => e.HealthInsuranceId).HasColumnName("health_insurance_id");
            entity.Property(e => e.LastName).HasColumnName("last_name");
            entity.Property(e => e.Occupation).HasColumnName("occupation");
            entity.Property(e => e.Phone).HasColumnName("phone");
            entity.Property(e => e.PhoneCountryId).HasColumnName("phone_country_id");
            entity.Property(e => e.ResidencyCountryId).HasColumnName("residency_country_id");
            entity.Property(e => e.ResidencyLocalityId).HasColumnName("residency_locality_id");
            entity.Property(e => e.ResidencyStateId).HasColumnName("residency_state_id");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.BirthplaceCountry).WithMany(p => p.UserProfileBirthplaceCountries)
                .HasForeignKey(d => d.BirthplaceCountryId)
                .HasConstraintName("user_profiles_birthplace_countries_fk");

            entity.HasOne(d => d.BirthplaceLocality).WithMany(p => p.UserProfileBirthplaceLocalities)
                .HasForeignKey(d => d.BirthplaceLocalityId)
                .HasConstraintName("user_profiles_birthplace_localities_fk");

            entity.HasOne(d => d.BirthplaceState).WithMany(p => p.UserProfileBirthplaceStates)
                .HasForeignKey(d => d.BirthplaceStateId)
                .HasConstraintName("user_profiles_birthplace_states_fk");

            entity.HasOne(d => d.BloodFactor).WithMany(p => p.UserProfiles)
                .HasForeignKey(d => d.BloodFactorId)
                .HasConstraintName("user_profiles_blood_factors_fk");

            entity.HasOne(d => d.BloodType).WithMany(p => p.UserProfiles)
                .HasForeignKey(d => d.BloodTypeId)
                .HasConstraintName("user_profiles_blood_types_fk");

            entity.HasOne(d => d.File).WithMany(p => p.UserProfiles)
                .HasForeignKey(d => d.FileId)
                .HasConstraintName("user_profiles_files_fk");

            entity.HasOne(d => d.Gender).WithMany(p => p.UserProfiles)
                .HasForeignKey(d => d.GenderId)
                .HasConstraintName("user_profiles_genders_fk");

            entity.HasOne(d => d.HealthInsurance).WithMany(p => p.UserProfiles)
                .HasForeignKey(d => d.HealthInsuranceId)
                .HasConstraintName("user_profiles_health_insurances_fk");

            entity.HasOne(d => d.ResidencyCountry).WithMany(p => p.UserProfileResidencyCountries)
                .HasForeignKey(d => d.ResidencyCountryId)
                .HasConstraintName("user_profiles_residency_countries_fk");

            entity.HasOne(d => d.ResidencyLocality).WithMany(p => p.UserProfileResidencyLocalities)
                .HasForeignKey(d => d.ResidencyLocalityId)
                .HasConstraintName("user_profiles_residency_localities_fk");

            entity.HasOne(d => d.ResidencyState).WithMany(p => p.UserProfileResidencyStates)
                .HasForeignKey(d => d.ResidencyStateId)
                .HasConstraintName("user_profiles_residency_states_fk");

            entity.HasOne(d => d.User).WithOne(p => p.UserProfile)
                .HasForeignKey<UserProfile>(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("user_profiles_users_fk");
        });

        modelBuilder.Entity<UserRecoveryCode>(entity =>
        {
            entity.HasKey(e => e.UserRecoveryCodeId).HasName("user_recovery_codes_pkey");

            entity.ToTable("user_recovery_codes");

            entity.Property(e => e.UserRecoveryCodeId)
                .HasDefaultValueSql("nextval('user_recovery_codes_user_recovery_code_id_seq1'::regclass)")
                .HasColumnName("user_recovery_code_id");
            entity.Property(e => e.Code).HasColumnName("code");
            entity.Property(e => e.CodeTypeId).HasColumnName("code_type_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.ExpiresAt).HasColumnName("expires_at");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.CodeType).WithMany(p => p.UserRecoveryCodes)
                .HasForeignKey(d => d.CodeTypeId)
                .HasConstraintName("user_recovery_codes_code_types_fk");

            entity.HasOne(d => d.User).WithMany(p => p.UserRecoveryCodes)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("user_recovery_codes_users_fk");
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(e => e.UserRoleId).HasName("user_roles_pkey");

            entity.ToTable("user_roles");

            entity.Property(e => e.UserRoleId)
                .HasDefaultValueSql("nextval('user_roles_user_role_id_seq1'::regclass)")
                .HasColumnName("user_role_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Role).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("user_roles_roles_fk");

            entity.HasOne(d => d.User).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("user_roles_users_fk");
        });

        modelBuilder.Entity<UserStep>(entity =>
        {
            entity.HasKey(e => e.UserStepId).HasName("user_steps_pkey");

            entity.ToTable("user_steps");

            entity.Property(e => e.UserStepId)
                .HasDefaultValueSql("nextval('user_steps_user_step_id_seq1'::regclass)")
                .HasColumnName("user_step_id");
            entity.Property(e => e.Completed)
                .HasDefaultValue(false)
                .HasColumnName("completed");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("timezone('utc'::text, now())")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.StepId).HasColumnName("step_id");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("timezone('utc'::text, now())")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
            entity.Property(e => e.UserProfileId).HasColumnName("user_profile_id");

            entity.HasOne(d => d.Step).WithMany(p => p.UserSteps)
                .HasForeignKey(d => d.StepId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("user_steps_steps_fk");

            entity.HasOne(d => d.UserProfile).WithMany(p => p.UserSteps)
                .HasForeignKey(d => d.UserProfileId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("user_steps_user_profiles_fk");
        });

        modelBuilder.Entity<Weekday>(entity =>
        {
            entity.HasKey(e => e.WeekdayId).HasName("weekdays_pkey");

            entity.ToTable("weekdays");

            entity.Property(e => e.WeekdayId)
                .HasDefaultValueSql("nextval('weekdays_weekday_id_seq1'::regclass)")
                .HasColumnName("weekday_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
        });
        modelBuilder.HasSequence("alarm_items_alarm_item_id_seq");
        modelBuilder.HasSequence("alarm_notification_type_alarm_notification_type_id_seq");
        modelBuilder.HasSequence("alarm_types_alarm_type_id_seq");
        modelBuilder.HasSequence("alarms_alarm_id_seq");
        modelBuilder.HasSequence("allergies_allergy_id_seq");
        modelBuilder.HasSequence("blood_factors_blood_factor_id_seq");
        modelBuilder.HasSequence("blood_types_blood_type_id_seq");
        modelBuilder.HasSequence("code_types_code_type_id_seq");
        modelBuilder.HasSequence("countries_country_id_seq");
        modelBuilder.HasSequence("diagnostics_daignostic_id_seq");
        modelBuilder.HasSequence("diseases_disease_id_seq");
        modelBuilder.HasSequence("documents_document_id_seq");
        modelBuilder.HasSequence("family_pathologies_family_pathology_id_seq");
        modelBuilder.HasSequence("family_types_family_type_id_seq");
        modelBuilder.HasSequence("files_file_id_seq");
        modelBuilder.HasSequence("folders_folder_id_seq");
        modelBuilder.HasSequence("genders_gender_id_seq");
        modelBuilder.HasSequence("health_insurances_health_insurance_id_seq");
        modelBuilder.HasSequence("health_metric_units_health_metric_unit_id_seq");
        modelBuilder.HasSequence("health_metrics_health_metric_id_seq");
        modelBuilder.HasSequence("health_tips_health_tip_id_seq");
        modelBuilder.HasSequence("interests_interest_id_seq");
        modelBuilder.HasSequence("localities_locality_id_seq");
        modelBuilder.HasSequence("medicines_medicine_id_seq");
        modelBuilder.HasSequence("post_share_types_post_share_type_id_seq");
        modelBuilder.HasSequence("post_types_post_type_id_seq");
        modelBuilder.HasSequence("roles_role_id_seq");
        modelBuilder.HasSequence("states_state_id_seq");
        modelBuilder.HasSequence("steps_steps_id_seq");
        modelBuilder.HasSequence("toxic_habits_toxic_habit_id_seq");
        modelBuilder.HasSequence("user_health_metrics_user_health_metric_id_seq");
        modelBuilder.HasSequence("user_interests_user_interest_id_seq");
        modelBuilder.HasSequence("user_medicines_user_medicine_id_seq");
        modelBuilder.HasSequence("user_pathologies_user_pathology_id_seq");
        modelBuilder.HasSequence("user_posts_user_post_id_seq");
        modelBuilder.HasSequence("user_profiles_user_profile_id_seq");
        modelBuilder.HasSequence("user_recovery_codes_user_recovery_code_id_seq");
        modelBuilder.HasSequence("user_roles_user_role_id_seq");
        modelBuilder.HasSequence("user_steps_user_step_id_seq");
        modelBuilder.HasSequence("users_user_id_seq");
        modelBuilder.HasSequence("weekdays_weekday_id_seq");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
