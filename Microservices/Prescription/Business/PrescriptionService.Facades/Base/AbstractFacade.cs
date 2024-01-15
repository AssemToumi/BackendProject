using AutoMapper;

namespace Prescription.Facades.Base {
    public class AbstractFacade {
        protected readonly IMapper Mapper;

        protected AbstractFacade(IMapper mapper)
            => Mapper = mapper;
    }
}
