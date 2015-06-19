/*
 * Thrift does not have floats, only doubles. 
 * Unity largely uses floats though KSP itself uses doubles in several structures
 * 
 * Vector3 and Vector3d being a example. 
 * Which in that specific case, Vector3's are all transformed to Vector3d in the API services and structs.
 * In these cases, when the extension method naming will use ToUnity for the float based structure and ToKsp for double based.
 * in most cases there will be only ToKsp and ToApi, unless there are 2 game variants like vector3.
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace KerbalApi
{
    public static class TransformerExtensions
    {

        public static Api.Game ToApi(this Game k)
        {
            return new Api.Game
            {
                Title = k.Title,
                Status = (Api.GameStatus)Enum.Parse(typeof(Api.GameStatus), k.Status.ToString()),
                StartScene = (Api.GameScenes)Enum.Parse(typeof(Api.GameScenes), k.startScene.ToString()),
                Mode = (Api.GameModes)Enum.Parse(typeof(Api.GameModes), k.Mode.ToString()),
                LoadedScene = (Api.GameScenes)Enum.Parse(typeof(Api.GameScenes), HighLogic.LoadedScene.ToString()),
            };
        }
        public static Api.Vessel ToApiVessel(this Vessel k)
        {
            var a = new Api.Vessel
            {
                Id = k.id.ToString(),
                Name = k.vesselName,
                Position = k.transform.position.ToApi(),
                Type = (Api.VesselType) Enum.Parse(typeof (Api.VesselType), k.vesselType.ToString()),
                Situation = (Api.VesselSituation)Enum.Parse(typeof(Api.VesselSituation), k.situation.ToString()),
                Orbit = k.orbit.ToApi(),
                MET = k.missionTime,

                Mass = k.parts.Where(p => p.IsPhysicallySignificant()).Sum(p => p.TotalMass()),
                DryMass = k.parts.Where(p => p.IsPhysicallySignificant()).Sum(p => p.DryMass()),


                Parts = k.ToApiParts()
            };
            a.Thrust = a.Parts.Engines.Where(e => e.Active).Sum(e => e.Thrust);
            a.AvailableThrust = a.Parts.Engines.Where(e => e.Active).Sum(e => e.AvailableThrust);
            a.MaxThrust = a.Parts.Engines.Where(e => e.Active).Sum(e => e.MaxThrust);
            a.MaxVacThrust = a.Parts.Engines.Where(e => e.Active).Sum(e => e.MaxVacThrust);

            double fuelConsumption = 0f;
            fuelConsumption = a.Parts.Engines.Where(e => e.Active).Sum(e => e.MaxThrust / e.SpecificImpulse);
            a.SpecificImpulse = fuelConsumption > 0f ? a.MaxThrust / fuelConsumption : 0f;

            fuelConsumption = a.Parts.Engines.Where(e => e.Active).Sum(e => e.MaxThrust / e.VacuumSpecificImpulse);
            a.VacuumSpecificImpulse = fuelConsumption > 0f ? a.MaxThrust / fuelConsumption : 0f;

            fuelConsumption = a.Parts.Engines.Where(e => e.Active).Sum(e => e.MaxThrust / e.KerbinSeaLevelSpecificImpulse);
            a.KerbinSeaLevelSpecificImpulse = fuelConsumption > 0f ? a.MaxThrust / fuelConsumption : 0f;
            
            

            return a;
        }
        public static Api.CelestialBody ToApi(this CelestialBody k)
        {
            var a = new Api.CelestialBody
            {
                Name = k.bodyName,
                Mass = k.Mass,
                Sattelites = new List<Api.CelestialBody>(),
                GravitationalParameter = k.gravParameter,
                SurfaceGravity = k.GeeASL * 9.81f,
                RotationPeriod = k.rotationPeriod,
                RotationalSpeed = (2f * Math.PI) / k.rotationPeriod,
                EquatorialRadius = k.Radius,
                SphereOfInfluence = k.sphereOfInfluence,
                HasAtmosphere = k.atmosphere,
                AtmosphereDepth = k.atmosphereDepth,
                HasAtmosphericOxygen = k.atmosphereContainsOxygen
            };
            if (k.orbit != null) a.Orbit = k.orbit.ToApi();

            foreach (var body in k.orbitingBodies)
            {
                a.Sattelites.Add(body.ToApi());
            }
            return a;
        }
        // ksp v3d => api v3d
        public static Api.Orbit ToApi(this Orbit k)
        {
            var a = new Api.Orbit
            {
                Apoasis = k.ApR,
                Periapsis = k.PeR,
                ApoasisAltitude = k.ApA,
                PeriapsisAltitude = k.PeA,
                SemiMajorAxis = 0.5d*(k.ApR + k.PeR),
                SemiMinorAxis = (0.5d*(k.ApR + k.PeR))*Math.Sqrt(1d - (k.eccentricity*k.eccentricity)),
                Radius = k.radius,
                Speed = k.orbitalSpeed,
                Period = k.period,
                TimeToApoasis = k.timeToAp,
                TimeToPeriapsis = k.timeToPe,
                Eccentricity = k.eccentricity,
                Inclination = k.inclination*(Math.PI/180d),
                LongitudeOfAscendingNode = k.LAN*(Math.PI/180d),
                ArgumentOfPeriapsis = k.argumentOfPeriapsis*(Math.PI/180d),
                MeanAnomalyAtEpoch = k.meanAnomalyAtEpoch,
                Epoch = k.epoch,
                MeanAnomaly = k.meanAnomaly,
                EccentricAnomaly = k.eccentricAnomaly
            };
            return a;
        }




        // ksp Part => api Part
        public static Api.Part ToApi(this Part k)
        {
            var massless = k.physicalSignificance == Part.PhysicalSignificance.NONE;
            var a = new Api.Part
            {
                Id = k.ApiFlightID(),
                Name = k.partInfo.name,
                Title = k.partInfo.title,
                Cost = k.partInfo.cost.ToDouble(),
                State = (Api.PartStates)Enum.Parse(typeof(Api.PartStates), k.State.ToString()),
                AxiallyAttached = k.parent != null && k.attachMode == AttachModes.STACK,
                RadiallyAttached = k.parent != null && k.attachMode == AttachModes.SRF_ATTACH,
                Stage = k.hasStagingIcon ? k.inverseStage : -1,
                DecoupleStage = 0,
                Massless = massless,
                Mass = massless ? 0f : (k.mass + k.GetResourceMass()) * 1000f,
                DryMass = massless ? 0f : k.mass * 1000f,
                ImpactTolerance = k.crashTolerance,
                Temperature = k.temperature,
                MaxTemperature = k.maxTemp,
                Crossfeed = k.fuelCrossFeed,
                FuelLinesFrom = k.fuelLookupTargets.Select(x => Convert.ToInt64(x.parent.flightID)).ToList(),
                Modules = k.Modules.ToApi(),
                IsDecoupler = k.HasModule<ModuleDecouple>() || k.HasModule<ModuleAnchoredDecoupler>(),
                IsDockingPort = k.HasModule<ModuleDockingNode>(),
                IsEngine = k.HasModule<ModuleEngines>() || k.HasModule<ModuleEnginesFX>(),
                IsLandingGear = k.HasModule<ModuleLandingGear>(),
                IsLandingLeg = k.HasModule<ModuleLandingLeg>(),
                IsLaunchClamp = k.HasModule<LaunchClamp>(),
                IsLight = k.HasModule<ModuleLight>(),
                IsSensor = k.HasModule<ModuleEnviroSensor>(),
                IsReactionWheel = k.HasModule<ModuleReactionWheel>(),
                IsParachute = k.HasModule<ModuleParachute>(),
                IsSolarPanel = k.HasModule<ModuleDeployableSolarPanel>()
            };

            if (k.parent != null) a.ParentId = Convert.ToInt64(k.parent.flightID);

            a.Children = new List<long>();
            foreach (var child in k.children)
            {
                a.Children.Add(Convert.ToInt64(child.flightID));
            }

            if (a.IsDecoupler) a.Decoupler = k.ToApiDecoupler();
            if (a.IsDockingPort) a.DockingPort = k.ToApiDockingPort();
            if (a.IsEngine) a.Engine = k.ToApiEngine();
            if (a.IsLandingGear) a.LandingGear = k.ToApiLandingGear();
            if (a.IsLandingLeg) a.LandingLeg = k.ToApiLandingLeg();
            if (a.IsLaunchClamp) a.LaunchClamp = k.ToApiLaunchClamp();
            if (a.IsLight) a.Light = k.ToApiLight();
            if (a.IsSensor) a.Sensor = k.ToApiSensor();
            if (a.IsReactionWheel) a.ReactionWheel = k.ToApiReactionWheel();
            if (a.IsParachute) a.Parachute = k.ToApiParachute();
            if (a.IsSolarPanel) a.SolarPanel = k.ToApiSolarPanel();

            return a;
        }
        public static Api.Parts ToApiParts(this Vessel k)
        {

            var ap = new Api.Parts
            {
                Capacity = k.parts.Capacity,
                Count = k.parts.Count,
                Root = k.rootPart.ToApi(),
                All = new List<Api.Part>(),
                Decouplers = new List<Api.Decoupler>(),
                DockingPorts = new List<Api.DockingPort>(),
                Engines = new List<Api.Engine>(),
                LandingGear = new List<Api.LandingGear>(),
                LandingLegs = new List<Api.LandingLeg>(),
                LaunchClamps = new List<Api.LaunchClamp>(),
                Lights = new List<Api.Light>(),
                Sensors = new List<Api.Sensor>(),
                ReactionWheels = new List<Api.ReactionWheel>(),
                Parachutes = new List<Api.Parachute>(),
                SolarPanels = new List<Api.SolarPanel>(),
            };
            foreach (Part p in k.parts)
            {
                var a = p.ToApi();
                ap.All.Add(a);

                if (a.IsDecoupler) ap.Decouplers.Add(a.Decoupler);
                if (a.IsDockingPort) ap.DockingPorts.Add(a.DockingPort);
                if (a.IsEngine) ap.Engines.Add(a.Engine);
                if (a.IsLandingGear) ap.LandingGear.Add(a.LandingGear);
                if (a.IsLandingLeg) ap.LandingLegs.Add(a.LandingLeg);
                //if (a.IsLaunchClamp) ap.LaunchClamps.Add();
                if (a.IsLight) ap.Lights.Add(a.Light);
                if (a.IsSensor) ap.Sensors.Add(a.Sensor);
                if (a.IsReactionWheel) ap.ReactionWheels.Add(a.ReactionWheel);
                if (a.IsParachute) ap.Parachutes.Add(a.Parachute);
                if (a.IsSolarPanel) ap.SolarPanels.Add(a.SolarPanel);

            }
            return ap;
        }
        public static Api.Module ToApi(this PartModule k)
        {
            return new Api.Module
            {
                Name = k.moduleName,
                Enabled = k.isEnabled,
                PartId = Convert.ToInt64(k.part.flightID),
                VesselId = k.vessel.id.ToString()
            };
        }
        // ksp PartModuleList > api List<Module>
        public static List<Api.Module> ToApi(this PartModuleList k)
        {
            var a = new List<Api.Module>();
            foreach (PartModule m in k)
            {
                a.Add(m.ToApi());
            }
            return a;
        }


        #region Part Modules (engine, lights, etc)

        public static long ApiFlightID(this Part k)
        {
            return Convert.ToInt64(k.flightID);
        }

        public static Api.Decoupler ToApiDecoupler(this Part k)
        {
            if (!k.HasModule<ModuleDecouple>() && !k.HasModule<ModuleAnchoredDecoupler>()) return null;
            //var aa = k.Module<ModuleFuelJettison>();
            
            var decoupler = k.Module<ModuleDecouple>();
            var anchoredDecoupler = k.Module<ModuleAnchoredDecoupler>();

            return new Api.Decoupler
            {
                PartId = k.ApiFlightID(),
                Decoupled = decoupler != null ? decoupler.isDecoupled : anchoredDecoupler.isDecoupled,
                Impulse = decoupler != null ? decoupler.ejectionForce : anchoredDecoupler.ejectionForce
            };
        }

        public static Api.DockingPort ToApiDockingPort(this Part k)
        {
            if (!k.HasModule<ModuleDockingNode>()) return null;

            var port = k.Module<ModuleDockingNode>();
            var shield = k.Module<ModuleAnimateGeneric>();

            return new Api.DockingPort
            {
                PartId = k.ApiFlightID(),
                State = (Api.DockingPortState)Enum.Parse(typeof(Api.DockingPortState), port.state),
                ReEngageDistance = port.minDistanceToReEngage,
                HasShield = shield != null,
                Shielded = shield != null && port.state == "Shielded",
                DockedPart = Convert.ToInt64(port.GetDockedPart().flightID)
            };
        }

        public static float GetEngineThrust(ModuleEngines engine, float throttle, double pressure)
        {
            pressure *= PhysicsGlobals.KpaToAtmospheres;
            return 1000f*throttle*engine.maxFuelFlow*engine.g*engine.atmosphereCurve.Evaluate((float) pressure);
        }

        public static float GetEngineThrust(ModuleEnginesFX engine, float throttle, double pressure)
        {
            return GetEngineThrust(engine, throttle, pressure);
        }

        public static Api.Engine ToApiEngine(this Part k)
        {
            if (!k.HasModule<ModuleEngines>() && !k.HasModule<ModuleEnginesFX>()) return null;
            var engine = k.Module<ModuleEngines>();
            var engineFx = k.Module<ModuleEnginesFX>();
            var gimbal = k.Module<ModuleGimbal>();

            var main = engine != null ? engine : engineFx;
            var throttle = engine != null ? engine.currentThrottle : engineFx.currentThrottle;
            var pKa = k.vessel.staticPressurekPa;
            var gimbalLimit = 1f;
            if (gimbal != null) gimbalLimit = gimbal.gimbalLock ? 0f : gimbal.gimbalLimiter/100f;

            return new Api.Engine
            {
                PartId = k.ApiFlightID(),
                Active = main.EngineIgnited,
                Thrust = GetEngineThrust(main, throttle, pKa).ToDouble(),
                AvailableThrust = GetEngineThrust(main, main.thrustPercentage/100f, pKa).ToDouble(),
                MaxThrust = GetEngineThrust(main, 1f, pKa).ToDouble(),
                MaxVacThrust = main.maxThrust*1000f,
                ThrustLimit = main.thrustPercentage/100f,
                SpecificImpulse = main.realIsp,
                VacuumSpecificImpulse = main.atmosphereCurve.Evaluate(0),
                KerbinSeaLevelSpecificImpulse = main.atmosphereCurve.Evaluate(1),
                //Propellants = 
                //PropellantRatios = 
                HasFuel = main.flameout,
                Throttle = main.currentThrottle,
                ThrottleLocked = main.throttleLocked,
                CanRestart = main.allowShutdown && main.allowRestart,
                CanShutdown = main.allowShutdown,
                Gimballed = gimbal != null,
                GimbalRange = gimbal != null && !gimbal.gimbalLock ? gimbal.gimbalRange : 0f,
                GimbalLocked = gimbal != null && gimbal.gimbalLock,
                GimbalLimit = gimbalLimit
            };
        }

        public static Api.LandingGear ToApiLandingGear(this Part k)
        {
            if (!k.HasModule<ModuleLandingGear>()) return null;
            var mod = k.Module<ModuleLandingGear>();
            return new Api.LandingGear
            {
                PartId = k.ApiFlightID(),
                State = (Api.LandingGearStates)Enum.Parse(typeof(Api.LandingGearStates), mod.gearState.ToString()),
                Deployed = mod.gearState.Equals(ModuleLandingGear.GearStates.DEPLOYED)
            };
        }

        public static Api.LandingLeg ToApiLandingLeg(this Part k)
        {
            if (!k.HasModule<ModuleLandingLeg>()) return null;
            var mod = k.Module<ModuleLandingLeg>();
            return new Api.LandingLeg
            {
                PartId = k.ApiFlightID(),
                State = (Api.LandingLegStates)Enum.Parse(typeof(Api.LandingLegStates), mod.legState.ToString()),
                Deployed = mod.legState.Equals(ModuleLandingLeg.LegStates.DEPLOYED)
            };
        }

        public static Api.LaunchClamp ToApiLaunchClamp(this Part k)
        {
            return new Api.LaunchClamp();
            {

            };
        }

        public static Api.Light ToApiLight(this Part k)
        {
            if (!k.HasModule<ModuleLight>()) return null;
            var mod = k.Module<ModuleLight>();
            return new Api.Light
            {
                PartId = k.ApiFlightID(),
                Active = mod.isOn,
                PowerUsage = mod.isOn ? mod.resourceAmount : 0f
            };
        }

        public static Api.Parachute ToApiParachute(this Part k)
        {
            if (!k.HasModule<ModuleParachute>()) return null;
            var mod = k.Module<ModuleParachute>();
            return new Api.Parachute
            {
                PartId = k.ApiFlightID(),
                State = (Api.ParachuteState)Enum.Parse(typeof(Api.ParachuteState), mod.deploymentState.ToString()),
                Deployed = mod.deploymentState != ModuleParachute.deploymentStates.STOWED,
                DeployAltitude = mod.deployAltitude.ToDouble(),
                DeployMinPressure = mod.minAirPressureToOpen.ToDouble()
            };
        }

        public static Api.ReactionWheel ToApiReactionWheel(this Part k)
        {
            if (!k.HasModule<ModuleReactionWheel>()) return null;
            var mod = k.Module<ModuleReactionWheel>();
            return new Api.ReactionWheel
            {
                PartId = k.ApiFlightID(),
                Active = mod.operational && mod.State.Equals(ModuleReactionWheel.WheelState.Active),
                Broken = mod.State.Equals(ModuleReactionWheel.WheelState.Broken),
                PitchTorque = mod.PitchTorque.ToDouble(),
                YawTorque = mod.YawTorque.ToDouble(),
                RollTorque = mod.RollTorque.ToDouble()
            };
        }

        public static Api.Sensor ToApiSensor(this Part k)
        {
            if (!k.HasModule<ModuleEnviroSensor>()) return null;
            var mod = k.Module<ModuleEnviroSensor>();
            return new Api.Sensor
            {
                PartId = k.ApiFlightID(),
                Active = mod.sensorActive,
                Value = mod.readoutInfo,
                PowerUsage = mod.powerConsumption.ToDouble()
            };
        }

        public static Api.SolarPanel ToApiSolarPanel(this Part k)
        {
            if (!k.HasModule<ModuleDeployableSolarPanel>()) return null;
            var panel = k.Module<ModuleDeployableSolarPanel>();
            return new Api.SolarPanel
            {
                PartId = k.ApiFlightID(),
                Deployed =
                    panel.panelState == ModuleDeployableSolarPanel.panelStates.EXTENDED ||
                    panel.panelState == ModuleDeployableSolarPanel.panelStates.EXTENDING,
                State = (Api.SolarPanelState)Enum.Parse(typeof(Api.SolarPanelState), panel.panelState.ToString()),
                EnergyFlow = panel.flowRate.ToDouble(),
                SunExposure = panel.sunAOA.ToDouble()
            };
        }

        #endregion Part Modules (engine, lights, etc)




        // ksp List<Part> > api List<Part>
        public static List<Api.Part> ToApi(this List<Part> k)
        {
            return k.Select(p => p.ToApi()).ToList();
        }


        #region Vector3 / Vector 3d

        // ksp v3d => api v3d
        public static Api.Vector3d ToApi(this Vector3d k)
        {
            var s = new Api.Vector3d
            {
                X = k.x,
                Y = k.y,
                Z = k.z,
                AsString = k.ToString(),
                Magnitude = k.magnitude,
                SqrMagnitude = k.sqrMagnitude
            };
            return s;
        }

        // unity v3 => api v3d
        public static Api.Vector3d ToApi(this Vector3 k)
        {
            var s = new Api.Vector3d
            {
                X = k.x.ToDouble(),
                Y = k.y.ToDouble(),
                Z = k.z.ToDouble(),
                AsString = k.ToString(),
                Magnitude = k.magnitude.ToDouble(),
                SqrMagnitude = k.sqrMagnitude.ToDouble()
            };
            return s;
        }

        // api v3d => unity v3
        public static Vector3 ToUnity(this Api.Vector3d s)
        {
            return new Vector3(s.X.ToFloat(), s.Y.ToFloat(), s.Z.ToFloat());
        }

        // api v3d => ksp v3d
        public static Vector3d ToKsp(this Api.Vector3d s)
        {
            return new Vector3d(s.X, s.Y, s.Z);
        }

        #endregion

        #region Primitives

        public static double ToDouble(this float val)
        {
            return Convert.ToDouble(val);
        }

        public static float ToFloat(this double val)
        {
            return (float) val;
        }

        #endregion primitives
    }
}