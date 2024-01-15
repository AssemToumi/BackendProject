using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helper;
using PrescriptionService.Models.PrescriptionService.Model.Abstractions;

namespace PrescriptionService.Models.PrescriptionService.Model;

[RegisterAsComponent]
public class ConnectedUser : IConnectedUser
{
    public long Id { get; set; }
}
