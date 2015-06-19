/**
 * Autogenerated by Thrift Compiler (0.9.2)
 *
 * DO NOT EDIT UNLESS YOU ARE SURE THAT YOU KNOW WHAT YOU ARE DOING
 *  @generated
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Thrift;
using Thrift.Collections;
using System.Runtime.Serialization;
using Thrift.Protocol;
using Thrift.Transport;

namespace KerbalApi.Api
{

  #if !SILVERLIGHT
  [Serializable]
  #endif
  public partial class Parts : TBase
  {
    private int _capacity;
    private int _count;
    private Part _root;
    private List<Part> _all;
    private List<Decoupler> _decouplers;
    private List<DockingPort> _dockingPorts;
    private List<Engine> _engines;
    private List<LandingGear> _landingGear;
    private List<LandingLeg> _landingLegs;
    private List<LaunchClamp> _launchClamps;
    private List<Light> _lights;
    private List<Parachute> _parachutes;
    private List<ReactionWheel> _reactionWheels;
    private List<Sensor> _sensors;
    private List<SolarPanel> _solarPanels;

    public int Capacity
    {
      get
      {
        return _capacity;
      }
      set
      {
        __isset.capacity = true;
        this._capacity = value;
      }
    }

    public int Count
    {
      get
      {
        return _count;
      }
      set
      {
        __isset.count = true;
        this._count = value;
      }
    }

    public Part Root
    {
      get
      {
        return _root;
      }
      set
      {
        __isset.root = true;
        this._root = value;
      }
    }

    public List<Part> All
    {
      get
      {
        return _all;
      }
      set
      {
        __isset.all = true;
        this._all = value;
      }
    }

    public List<Decoupler> Decouplers
    {
      get
      {
        return _decouplers;
      }
      set
      {
        __isset.decouplers = true;
        this._decouplers = value;
      }
    }

    public List<DockingPort> DockingPorts
    {
      get
      {
        return _dockingPorts;
      }
      set
      {
        __isset.dockingPorts = true;
        this._dockingPorts = value;
      }
    }

    public List<Engine> Engines
    {
      get
      {
        return _engines;
      }
      set
      {
        __isset.engines = true;
        this._engines = value;
      }
    }

    public List<LandingGear> LandingGear
    {
      get
      {
        return _landingGear;
      }
      set
      {
        __isset.landingGear = true;
        this._landingGear = value;
      }
    }

    public List<LandingLeg> LandingLegs
    {
      get
      {
        return _landingLegs;
      }
      set
      {
        __isset.landingLegs = true;
        this._landingLegs = value;
      }
    }

    public List<LaunchClamp> LaunchClamps
    {
      get
      {
        return _launchClamps;
      }
      set
      {
        __isset.launchClamps = true;
        this._launchClamps = value;
      }
    }

    public List<Light> Lights
    {
      get
      {
        return _lights;
      }
      set
      {
        __isset.lights = true;
        this._lights = value;
      }
    }

    public List<Parachute> Parachutes
    {
      get
      {
        return _parachutes;
      }
      set
      {
        __isset.parachutes = true;
        this._parachutes = value;
      }
    }

    public List<ReactionWheel> ReactionWheels
    {
      get
      {
        return _reactionWheels;
      }
      set
      {
        __isset.reactionWheels = true;
        this._reactionWheels = value;
      }
    }

    public List<Sensor> Sensors
    {
      get
      {
        return _sensors;
      }
      set
      {
        __isset.sensors = true;
        this._sensors = value;
      }
    }

    public List<SolarPanel> SolarPanels
    {
      get
      {
        return _solarPanels;
      }
      set
      {
        __isset.solarPanels = true;
        this._solarPanels = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool capacity;
      public bool count;
      public bool root;
      public bool all;
      public bool decouplers;
      public bool dockingPorts;
      public bool engines;
      public bool landingGear;
      public bool landingLegs;
      public bool launchClamps;
      public bool lights;
      public bool parachutes;
      public bool reactionWheels;
      public bool sensors;
      public bool solarPanels;
    }

    public Parts() {
    }

    public void Read (TProtocol iprot)
    {
      TField field;
      iprot.ReadStructBegin();
      while (true)
      {
        field = iprot.ReadFieldBegin();
        if (field.Type == TType.Stop) { 
          break;
        }
        switch (field.ID)
        {
          case 1:
            if (field.Type == TType.I32) {
              Capacity = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 2:
            if (field.Type == TType.I32) {
              Count = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 3:
            if (field.Type == TType.Struct) {
              Root = new Part();
              Root.Read(iprot);
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 11:
            if (field.Type == TType.List) {
              {
                All = new List<Part>();
                TList _list25 = iprot.ReadListBegin();
                for( int _i26 = 0; _i26 < _list25.Count; ++_i26)
                {
                  Part _elem27;
                  _elem27 = new Part();
                  _elem27.Read(iprot);
                  All.Add(_elem27);
                }
                iprot.ReadListEnd();
              }
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 21:
            if (field.Type == TType.List) {
              {
                Decouplers = new List<Decoupler>();
                TList _list28 = iprot.ReadListBegin();
                for( int _i29 = 0; _i29 < _list28.Count; ++_i29)
                {
                  Decoupler _elem30;
                  _elem30 = new Decoupler();
                  _elem30.Read(iprot);
                  Decouplers.Add(_elem30);
                }
                iprot.ReadListEnd();
              }
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 22:
            if (field.Type == TType.List) {
              {
                DockingPorts = new List<DockingPort>();
                TList _list31 = iprot.ReadListBegin();
                for( int _i32 = 0; _i32 < _list31.Count; ++_i32)
                {
                  DockingPort _elem33;
                  _elem33 = new DockingPort();
                  _elem33.Read(iprot);
                  DockingPorts.Add(_elem33);
                }
                iprot.ReadListEnd();
              }
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 23:
            if (field.Type == TType.List) {
              {
                Engines = new List<Engine>();
                TList _list34 = iprot.ReadListBegin();
                for( int _i35 = 0; _i35 < _list34.Count; ++_i35)
                {
                  Engine _elem36;
                  _elem36 = new Engine();
                  _elem36.Read(iprot);
                  Engines.Add(_elem36);
                }
                iprot.ReadListEnd();
              }
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 24:
            if (field.Type == TType.List) {
              {
                LandingGear = new List<LandingGear>();
                TList _list37 = iprot.ReadListBegin();
                for( int _i38 = 0; _i38 < _list37.Count; ++_i38)
                {
                  LandingGear _elem39;
                  _elem39 = new LandingGear();
                  _elem39.Read(iprot);
                  LandingGear.Add(_elem39);
                }
                iprot.ReadListEnd();
              }
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 25:
            if (field.Type == TType.List) {
              {
                LandingLegs = new List<LandingLeg>();
                TList _list40 = iprot.ReadListBegin();
                for( int _i41 = 0; _i41 < _list40.Count; ++_i41)
                {
                  LandingLeg _elem42;
                  _elem42 = new LandingLeg();
                  _elem42.Read(iprot);
                  LandingLegs.Add(_elem42);
                }
                iprot.ReadListEnd();
              }
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 26:
            if (field.Type == TType.List) {
              {
                LaunchClamps = new List<LaunchClamp>();
                TList _list43 = iprot.ReadListBegin();
                for( int _i44 = 0; _i44 < _list43.Count; ++_i44)
                {
                  LaunchClamp _elem45;
                  _elem45 = new LaunchClamp();
                  _elem45.Read(iprot);
                  LaunchClamps.Add(_elem45);
                }
                iprot.ReadListEnd();
              }
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 27:
            if (field.Type == TType.List) {
              {
                Lights = new List<Light>();
                TList _list46 = iprot.ReadListBegin();
                for( int _i47 = 0; _i47 < _list46.Count; ++_i47)
                {
                  Light _elem48;
                  _elem48 = new Light();
                  _elem48.Read(iprot);
                  Lights.Add(_elem48);
                }
                iprot.ReadListEnd();
              }
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 28:
            if (field.Type == TType.List) {
              {
                Parachutes = new List<Parachute>();
                TList _list49 = iprot.ReadListBegin();
                for( int _i50 = 0; _i50 < _list49.Count; ++_i50)
                {
                  Parachute _elem51;
                  _elem51 = new Parachute();
                  _elem51.Read(iprot);
                  Parachutes.Add(_elem51);
                }
                iprot.ReadListEnd();
              }
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 29:
            if (field.Type == TType.List) {
              {
                ReactionWheels = new List<ReactionWheel>();
                TList _list52 = iprot.ReadListBegin();
                for( int _i53 = 0; _i53 < _list52.Count; ++_i53)
                {
                  ReactionWheel _elem54;
                  _elem54 = new ReactionWheel();
                  _elem54.Read(iprot);
                  ReactionWheels.Add(_elem54);
                }
                iprot.ReadListEnd();
              }
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 30:
            if (field.Type == TType.List) {
              {
                Sensors = new List<Sensor>();
                TList _list55 = iprot.ReadListBegin();
                for( int _i56 = 0; _i56 < _list55.Count; ++_i56)
                {
                  Sensor _elem57;
                  _elem57 = new Sensor();
                  _elem57.Read(iprot);
                  Sensors.Add(_elem57);
                }
                iprot.ReadListEnd();
              }
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 31:
            if (field.Type == TType.List) {
              {
                SolarPanels = new List<SolarPanel>();
                TList _list58 = iprot.ReadListBegin();
                for( int _i59 = 0; _i59 < _list58.Count; ++_i59)
                {
                  SolarPanel _elem60;
                  _elem60 = new SolarPanel();
                  _elem60.Read(iprot);
                  SolarPanels.Add(_elem60);
                }
                iprot.ReadListEnd();
              }
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          default: 
            TProtocolUtil.Skip(iprot, field.Type);
            break;
        }
        iprot.ReadFieldEnd();
      }
      iprot.ReadStructEnd();
    }

    public void Write(TProtocol oprot) {
      TStruct struc = new TStruct("Parts");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (__isset.capacity) {
        field.Name = "capacity";
        field.Type = TType.I32;
        field.ID = 1;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(Capacity);
        oprot.WriteFieldEnd();
      }
      if (__isset.count) {
        field.Name = "count";
        field.Type = TType.I32;
        field.ID = 2;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(Count);
        oprot.WriteFieldEnd();
      }
      if (Root != null && __isset.root) {
        field.Name = "root";
        field.Type = TType.Struct;
        field.ID = 3;
        oprot.WriteFieldBegin(field);
        Root.Write(oprot);
        oprot.WriteFieldEnd();
      }
      if (All != null && __isset.all) {
        field.Name = "all";
        field.Type = TType.List;
        field.ID = 11;
        oprot.WriteFieldBegin(field);
        {
          oprot.WriteListBegin(new TList(TType.Struct, All.Count));
          foreach (Part _iter61 in All)
          {
            _iter61.Write(oprot);
          }
          oprot.WriteListEnd();
        }
        oprot.WriteFieldEnd();
      }
      if (Decouplers != null && __isset.decouplers) {
        field.Name = "decouplers";
        field.Type = TType.List;
        field.ID = 21;
        oprot.WriteFieldBegin(field);
        {
          oprot.WriteListBegin(new TList(TType.Struct, Decouplers.Count));
          foreach (Decoupler _iter62 in Decouplers)
          {
            _iter62.Write(oprot);
          }
          oprot.WriteListEnd();
        }
        oprot.WriteFieldEnd();
      }
      if (DockingPorts != null && __isset.dockingPorts) {
        field.Name = "dockingPorts";
        field.Type = TType.List;
        field.ID = 22;
        oprot.WriteFieldBegin(field);
        {
          oprot.WriteListBegin(new TList(TType.Struct, DockingPorts.Count));
          foreach (DockingPort _iter63 in DockingPorts)
          {
            _iter63.Write(oprot);
          }
          oprot.WriteListEnd();
        }
        oprot.WriteFieldEnd();
      }
      if (Engines != null && __isset.engines) {
        field.Name = "engines";
        field.Type = TType.List;
        field.ID = 23;
        oprot.WriteFieldBegin(field);
        {
          oprot.WriteListBegin(new TList(TType.Struct, Engines.Count));
          foreach (Engine _iter64 in Engines)
          {
            _iter64.Write(oprot);
          }
          oprot.WriteListEnd();
        }
        oprot.WriteFieldEnd();
      }
      if (LandingGear != null && __isset.landingGear) {
        field.Name = "landingGear";
        field.Type = TType.List;
        field.ID = 24;
        oprot.WriteFieldBegin(field);
        {
          oprot.WriteListBegin(new TList(TType.Struct, LandingGear.Count));
          foreach (LandingGear _iter65 in LandingGear)
          {
            _iter65.Write(oprot);
          }
          oprot.WriteListEnd();
        }
        oprot.WriteFieldEnd();
      }
      if (LandingLegs != null && __isset.landingLegs) {
        field.Name = "landingLegs";
        field.Type = TType.List;
        field.ID = 25;
        oprot.WriteFieldBegin(field);
        {
          oprot.WriteListBegin(new TList(TType.Struct, LandingLegs.Count));
          foreach (LandingLeg _iter66 in LandingLegs)
          {
            _iter66.Write(oprot);
          }
          oprot.WriteListEnd();
        }
        oprot.WriteFieldEnd();
      }
      if (LaunchClamps != null && __isset.launchClamps) {
        field.Name = "launchClamps";
        field.Type = TType.List;
        field.ID = 26;
        oprot.WriteFieldBegin(field);
        {
          oprot.WriteListBegin(new TList(TType.Struct, LaunchClamps.Count));
          foreach (LaunchClamp _iter67 in LaunchClamps)
          {
            _iter67.Write(oprot);
          }
          oprot.WriteListEnd();
        }
        oprot.WriteFieldEnd();
      }
      if (Lights != null && __isset.lights) {
        field.Name = "lights";
        field.Type = TType.List;
        field.ID = 27;
        oprot.WriteFieldBegin(field);
        {
          oprot.WriteListBegin(new TList(TType.Struct, Lights.Count));
          foreach (Light _iter68 in Lights)
          {
            _iter68.Write(oprot);
          }
          oprot.WriteListEnd();
        }
        oprot.WriteFieldEnd();
      }
      if (Parachutes != null && __isset.parachutes) {
        field.Name = "parachutes";
        field.Type = TType.List;
        field.ID = 28;
        oprot.WriteFieldBegin(field);
        {
          oprot.WriteListBegin(new TList(TType.Struct, Parachutes.Count));
          foreach (Parachute _iter69 in Parachutes)
          {
            _iter69.Write(oprot);
          }
          oprot.WriteListEnd();
        }
        oprot.WriteFieldEnd();
      }
      if (ReactionWheels != null && __isset.reactionWheels) {
        field.Name = "reactionWheels";
        field.Type = TType.List;
        field.ID = 29;
        oprot.WriteFieldBegin(field);
        {
          oprot.WriteListBegin(new TList(TType.Struct, ReactionWheels.Count));
          foreach (ReactionWheel _iter70 in ReactionWheels)
          {
            _iter70.Write(oprot);
          }
          oprot.WriteListEnd();
        }
        oprot.WriteFieldEnd();
      }
      if (Sensors != null && __isset.sensors) {
        field.Name = "sensors";
        field.Type = TType.List;
        field.ID = 30;
        oprot.WriteFieldBegin(field);
        {
          oprot.WriteListBegin(new TList(TType.Struct, Sensors.Count));
          foreach (Sensor _iter71 in Sensors)
          {
            _iter71.Write(oprot);
          }
          oprot.WriteListEnd();
        }
        oprot.WriteFieldEnd();
      }
      if (SolarPanels != null && __isset.solarPanels) {
        field.Name = "solarPanels";
        field.Type = TType.List;
        field.ID = 31;
        oprot.WriteFieldBegin(field);
        {
          oprot.WriteListBegin(new TList(TType.Struct, SolarPanels.Count));
          foreach (SolarPanel _iter72 in SolarPanels)
          {
            _iter72.Write(oprot);
          }
          oprot.WriteListEnd();
        }
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder __sb = new StringBuilder("Parts(");
      bool __first = true;
      if (__isset.capacity) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Capacity: ");
        __sb.Append(Capacity);
      }
      if (__isset.count) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Count: ");
        __sb.Append(Count);
      }
      if (Root != null && __isset.root) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Root: ");
        __sb.Append(Root== null ? "<null>" : Root.ToString());
      }
      if (All != null && __isset.all) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("All: ");
        __sb.Append(All);
      }
      if (Decouplers != null && __isset.decouplers) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Decouplers: ");
        __sb.Append(Decouplers);
      }
      if (DockingPorts != null && __isset.dockingPorts) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("DockingPorts: ");
        __sb.Append(DockingPorts);
      }
      if (Engines != null && __isset.engines) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Engines: ");
        __sb.Append(Engines);
      }
      if (LandingGear != null && __isset.landingGear) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("LandingGear: ");
        __sb.Append(LandingGear);
      }
      if (LandingLegs != null && __isset.landingLegs) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("LandingLegs: ");
        __sb.Append(LandingLegs);
      }
      if (LaunchClamps != null && __isset.launchClamps) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("LaunchClamps: ");
        __sb.Append(LaunchClamps);
      }
      if (Lights != null && __isset.lights) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Lights: ");
        __sb.Append(Lights);
      }
      if (Parachutes != null && __isset.parachutes) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Parachutes: ");
        __sb.Append(Parachutes);
      }
      if (ReactionWheels != null && __isset.reactionWheels) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("ReactionWheels: ");
        __sb.Append(ReactionWheels);
      }
      if (Sensors != null && __isset.sensors) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Sensors: ");
        __sb.Append(Sensors);
      }
      if (SolarPanels != null && __isset.solarPanels) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("SolarPanels: ");
        __sb.Append(SolarPanels);
      }
      __sb.Append(")");
      return __sb.ToString();
    }

  }

}