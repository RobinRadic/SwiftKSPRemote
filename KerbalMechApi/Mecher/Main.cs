using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MuMech;
using VesselExtensions = KerbalApi.VesselExtensions;

namespace KerbalMechApi
{
    public static partial class Mecher
    {
        private static Vessel vessel { get { return FlightGlobals.ActiveVessel;  } }

        private static MuMech.MechJebCore core { get { return VesselExtensions.GetModules<MuMech.MechJebCore>(vessel)[0]; } }

        // Keep all Operation objects so parameters are saved
        static Operation[] operation = Operation.getAvailableOperations();
        private static string[] _operationNames;
        static int operationId = 0;

        public static string[] operationNames { get { return _operationNames ?? (_operationNames = new List<Operation>(operation).ConvertAll(x => x.getName()).ToArray());} }


        public enum Operation2

        {
            AdvancedTransfer, Apoapsis, Circularize, CourseCorrection, 
            Ellipticize, Inclination, InterplanitaryTransfer, KillRelVel, Lambert, Lan, Longitude, MoonReturn, 
            Periapsis, Plane, ResonantOrbit, SemiMajor, Transfer
        }

        public static void ExecuteOperation()
        {
            
        }
    }
}
