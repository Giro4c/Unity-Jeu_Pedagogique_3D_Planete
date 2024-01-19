# Unity-Jeu_Pedagogique_3D_Planete
Un jeu pédagogique 3D sur les différentes rotations de notre planète et le lien avec les phases jour/nuit et les saisons.
  
## Avertissement  
  
Le sdk pico importé en tant que package venant d'un fichier local, à l'ouverture du projet une erreur empechant la compilation peut se manifester, allez dans le Package Manager pour retirer le package. Si l'erreur persiste, alors rendez-vous dans :
* Project Settings -> XR Plug-in Managment (Android), et déselectionnez "PICO XR feature group" si l'option est affichée.  
* Project Settings -> XR Plug-in Managment -> OpenXR (Android), et supprimez le profil PICO s'il est présent.  

Il est aussi possible que le projet doive etre rechargé après la suppression du package pour faire partir l'erreur ou supprimez le dossier Library.