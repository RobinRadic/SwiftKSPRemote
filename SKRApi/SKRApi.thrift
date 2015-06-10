namespace csharp SKRApi

/**
 * Thrift lets you do typedefs to get pretty names for your types. Standard
 * C style here.
 */
typedef i32 MyInteger

const i32 INT32CONSTANT = 9853
const map<string,string> MAPCONSTANT = {'hello':'world', 'goodnight':'moon'}

enum Operation {
  ADD = 1,
  SUBTRACT = 2,
  MULTIPLY = 3,
  DIVIDE = 4
}

struct Work {
  1: i32 num1 = 0,
  2: i32 num2,
  3: Operation op,
  4: optional string comment,
}

/**
 * Structs can also be exceptions, if they are nasty.
 */
exception InvalidOperation {
  1: i32 what,
  2: string why
}

struct Vector3d {
    1: double x,
    2: double y,
    3: double z,
    4: Vector3d back,
    5: Vector3d down,
    6: Vector3d forward,
    7: Vector3d left,
    8: double magnitude,
    9: Vector3d normalized,
    10: Vector3d one,
    11: Vector3d right,
    12: double sqrMagnitude,
    13: Vector3d up,
    14: Vector3d zero,
    15: string asString
}

service SKRApiService {

   void ping(),

   i32 add(1:i32 num1, 2:i32 num2),
   string vesselName(),
   string test1(),
   string test2(),


   /*
   oneway modifier keyword may be added to a void function, which will generate code that does not wait for a response. 
   Note that a pure void function will return a response to the client which guarantees that the operation has completed on the server side. 
   With oneway method calls the client will only be guaranteed that the request succeeded at the transport layer. 
   */
   oneway void zip()

}
