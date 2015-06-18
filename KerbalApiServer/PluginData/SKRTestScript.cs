
foreach(Assembly ass in AppDomain.CurrentDomain.GetAssemblies()){
Debug.Log(
ass.GetTypes()
);
}