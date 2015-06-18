namespace csharp KerbalApi.Api

enum ErrorCode {
    /** If a parameter was invalid */
    INVALID_REQUEST = 0,
    /** Authentication failed */
    INVALID_AUTHSTRING = 1,
    /** Requested data could not be found */
    NOT_FOUND = 2,
    /** Something went wrong during a download operation */
    DOWNLOAD_ERROR = 3,
    /** Something went wrong during a file operation */
    FILE_ERROR = 4,
    /** Could not read a file */
    NO_READ = 5,
}

/** This exception is thrown when something data-related went wrong */
exception EDataException {
    /** Detailed reason for the exception */
	1: ErrorCode code,
    /** A message that describes the exception */
	2: string errorMessage,
}

/** Thrown when authentication fails, this is thrown */
exception EAuthException {
    /** Detailed reason for the exception */
	1: ErrorCode code,
    /** A message that describes the exception */
	2: string errorMessage,
}


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
    2: string status,
    3: GameScenes startScene,
    4: GameModes mode,
    // HighLogic
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


struct Vessel {
    1: Vector3d position,
    2: string name
}


struct FlightGlobals {
    1: Vessel activeVessel,
    2: list<Vessel> vessels
}

service KerbalApiService {
    oneway void evaluateCSCodeNoResponse(1:string authString),
    bool evaluateCSCode(1:string authString) throws (1:EAuthException aex),
    Vessel activeVessel(1:string authString) throws (1:EAuthException aex),
    FlightGlobals flightGlobals(1:string authString) throws (1:EAuthException aex),
   /*   oneway modifier keyword may be added to a void function, which will generate code that does not wait for a response.    Note that a pure void function will return a response to the client which guarantees that the operation has completed on the server side.    With oneway method calls the client will only be guaranteed that the request succeeded at the transport layer.    */   oneway void zip()

}
