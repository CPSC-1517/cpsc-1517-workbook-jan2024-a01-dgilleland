# Patching in `git`

To create a patch of specific files between two branches, use the following command:

```
git diff main HEAD -- ./path/to/file.txt ./another.txt > ./NoTrack/changes.patch
```

Then, switch to the branch you want to apply the patch to and run the following command:

```
git apply ./NoTrack/changes.patch
```
