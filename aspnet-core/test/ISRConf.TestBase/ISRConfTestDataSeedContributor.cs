using ISRConf.Conference.Participant;
using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace ISRConf;

public class ISRConfTestDataSeedContributor : IDataSeedContributor, ITransientDependency
{
    private readonly IRepository<Participant, Guid> _participantRepository;

    public ISRConfTestDataSeedContributor(IRepository<Participant, Guid> participantRepo)
    {
        _participantRepository = participantRepo;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        await _participantRepository.InsertAsync(
            new Participant(

                ISRConfTestConsts.testGuid1,
                "Alan",
                "Nowak",
                "alannowak@gmail.com",
                "123123123",
                TicketType.Normal
            ));

        await _participantRepository.InsertAsync(
            new Participant(

                ISRConfTestConsts.testGuid2,
                "Alan2",
                "Nowak2",
                "alannowak2@gmail.com",
                "123123123",
                TicketType.Concessionary
            ));
    }
}
