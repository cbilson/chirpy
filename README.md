Chirpy
------

Chirpy is a web content bundling tool. This is a fork. [The original is
on codeplex.](http://chirpy.codeplex.com/)

This fork was mainly to address a few problems we had running chirpy
from the command line, as part of our automated build process, namely:

* When there is an exception due to a file not being found, it now
  reports the file that was missing.
  
* Instead of always downloading javascript files (like UglifyJS, for
  example) it will first check to see if it has the file as an
  embedded resource, and use that instead.
  
License
-------
Chirpy is released unde the MS-PL. See the file LICENSE in this
repository for a complete copy of the license.
