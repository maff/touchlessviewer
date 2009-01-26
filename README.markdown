## Information ##

An imageviewer for windows built upon the Touchless SDK (<a href="http://www.codeplex.com/touchless">http://www.codeplex.com/touchless</a>)

## Setup ##

To be able to compile the project, it's neccessary to add TouchlessLib.dll and WebCamLib.dll from the Touchless SDK distribution to the directory TouchlessViewer/Library and the corresponding output directories.

<pre>+ - .gitignore
+ - README
+ - TouchlessViewer.sln
+ - TouchlessViewer
    + - [...]
    + - MainWindow.cs
    + - Library
        + - TouchlessLib.dll
        + - WebCamLib.dll
    + - bin
        + - debug
            + - TouchlessLib.dll
            + - WebCamLib.dll
        + - release
            + - TouchlessLib.dll
            + - WebCamLib.dll
    + - [...]</pre>
