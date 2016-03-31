Assignment3 Help:
I mark the update for assignment3 in my code using “Update Assignment3 note”
Using Action, Lambda expression, Func<>, Annonymous method.

Home Media Player:
1- All Album save in one default place My library.
2- Using Media Elemnt to display media file.
3- Using play.next, play.previous, play.stop, play.paus mediaElemnt mehod to control media flow.
4- Main window have 3 Sections: left for show album(Folder), right one display media file in selected folder, 
   therd one down rigth for playList file.

To Add new Album:
1- Click on Add new album (Plus Green Button), New Album window show.
2- Brows new file, Give album some name.
   copy and remove file from left sid to right side (Orginal folder new folder album).
3- When every things ok, click on OK. The new album Created and you can see it under My library TreeView.

How to use my share library and copy it to GAC:
1- Open setup project in Solution "Assignment1".
2- Brows Spcify Application Data.
3- Select Files.
4. In Source computer folder you can find my UtilitiesLib (My Share library).
5. In Destination computer right click on "Destination Computer", and chose "Show predefinde folder", 
   than select [GlobalAssamblyCash].
6. Back to Source computer Chose UtilitiesLib, three file will desplay on right side (Source computer file) 
   drag "Primary output..." to Destination Computer Files Or just copy and pest.
7. But make shore to Select [GlobalAssamblyCash] in Destination Computer folder before release or past in distination 
   computer files.
8. Build setup project.
9. Now if you brows to "C:\Windows\Microsoft.NET\assembly\GAC_MSIL" you will find "UtilitiesLib", this is my share assambly.
10. Just add referance to "system.UtilitiesLib" in your project and enjoy.

Hope this documentation help to undestande my project.