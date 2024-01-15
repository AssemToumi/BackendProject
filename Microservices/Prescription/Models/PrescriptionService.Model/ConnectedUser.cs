using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helper;
using Prescription.Models.Abstractions;

namespace Prescription.Models;

[RegisterAsComponent]
public class ConnectedUser : IConnectedUser {
    public long Id { get; set; }
}
