using AutoMapper;

namespace Rumo.WebMetasV2.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            //CreateMap<LegalPersonViewModel, RegisterNewLegalPersonCommand>()
            //    .ConstructUsing(c => new RegisterNewLegalPersonCommand(c.Name, c.Address, c.Number, c.Complement, c.Neighborhood, c.CityId,
            //                                                           c.DDDPrincipal, c.DDDCellPhone, c.TelephonePrincipal, c.CellPhone,
            //                                                           c.Email, c.Password, c.StateRegistration, c.CNPJ));

            //CreateMap<LegalPersonViewModel, UpdateLegalPersonCommand>()
            //    .ConstructUsing(c => new UpdateLegalPersonCommand(c.Id, c.Name, c.Address, c.Number, c.Complement, c.Neighborhood, c.CityId,
            //                                                      c.DDDPrincipal, c.DDDCellPhone, c.TelephonePrincipal, c.CellPhone,
            //                                                      c.Email, c.Password, c.StateRegistration, c.CNPJ));

           
        }
    }
}
