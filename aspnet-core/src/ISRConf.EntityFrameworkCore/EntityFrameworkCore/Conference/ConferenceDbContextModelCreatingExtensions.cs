using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;
using JetBrains.Annotations;
using ISRConf.Conference.Participant;

namespace ISRConf.EntityFrameworkCore.Conference
{
    public static class ConferenceDbContextModelCreatingExtensions
    {
        public static void ConfigureConference(
            [NotNull] this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            if (builder.IsTenantOnlyDatabase())
            {
                return;
            }

            builder.Entity<Participant>(b =>
            {
                b.ToTable(ISRConfConsts.DbTablePrefix + "Participants", ISRConfConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.FirstName).IsRequired().HasMaxLength(ParticipantConsts.MaxNameLength);
                b.Property(x => x.Surname).IsRequired().HasMaxLength(ParticipantConsts.MaxNameLength);
                b.Property(x => x.EmailAdress).IsRequired().HasMaxLength(ParticipantConsts.MaxEmailAdressLength);
                b.Property(x => x.PhoneNumber).IsRequired().HasMaxLength(ParticipantConsts.MaxPhoneNumberLength);
                b.Property(x => x.TicketType).IsRequired();
            });

        }
    }
}
