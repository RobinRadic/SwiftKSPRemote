/*
 * game.thrift :: Contains definitions for everything EXCLUDING vessel, parts/modules
 */

namespace csharp KerbalApi.Api

enum GameScenes {
    CREDITS,
    EDITOR,
    FLIGHT,
    LOADING,
    LOADINGBUFFER,
    MAINMENU,
    PSYSTEM,
    SETTINGS,
    SPACECENTER,
    TRACKSTATION
}

enum GameStatus {
    COMPLETED,
    FAILED_OR_ABORTED,
    ONGOING,
    UNSTARTED
}

enum GameModes {
    CAREER,
    SANDBOX,
    SCENARIO,
    SCENARIO_NON_RESUMABLE,
    SCIENCE_SANDBOX
}

enum EditorFacility {
    None,
    SPH,
    VAB
}

struct Game {
    1: string title,
    2: GameStatus status,
    3: GameScenes startScene,
    4: GameModes mode,
    5: GameScenes loadedScene
}

struct Vector3d {
    1: double x,
    2: double y,
    3: double z,
    4: double magnitude,
    5: double sqrMagnitude,
    6: string asString
}



struct CelestialBody {
    1: string name,
    2: double mass,
    3: list<CelestialBody> sattelites,
    4: double gravitationalParameter,
    5: double surfaceGravity,
    6: double rotationalSpeed,
    7: double rotationPeriod,
    8: double equatorialRadius,
    9: double sphereOfInfluence,
    10: bool hasAtmosphere,
    11: double atmosphereDepth,
    12: bool hasAtmosphericOxygen,
    13: Orbit orbit
}

struct Orbit {
    2: double apoasis,
    3: double periapsis,
    4: double apoasisAltitude,
    5: double periapsisAltitude,
    7: double semiMajorAxis,
    8: double semiMinorAxis,
    9: double radius,
    10: double speed,
    11: double period,
    12: double timeToApoasis,
    13: double timeToPeriapsis,
    14: double eccentricity,
    15: double inclination,
    16: double longitudeOfAscendingNode,
    17: double argumentOfPeriapsis,
    18: double meanAnomalyAtEpoch,
    19: double epoch,
    20: double meanAnomaly,
    21: double eccentricAnomaly
}

