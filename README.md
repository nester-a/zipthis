# How to instal `zipthis`

To use the `zipthis`, you must have `.net core 3.1` or higher installed on your computer.

For installation please type following command in console or terminal:
```
dotnet tool install --global zipthis
```

# How to use `zipthis`
## Start of use
To use the `zipthis` you need type following command in console or terminal:

```
>zipthis {zip archive name} {zip archive source} {zip archive destination}
```
Where:
* `{zip archive name}` - is final archive name. Default value is source directory name;
* `{zip archive source}` - is the source directory to be archived. Default value is 'zipthis' execution directory;
* `{zip archive destination}` - is directory where the archive will be created. Default value is 'zipthis' execution directory.

## Rules:

**All arguments are passed one by one one in turn.**

This rule imposes a restriction on the passing of `zipthis` arguments.

If you want to pass in command `{zip archive source}` argument at first you need to pass `{zip archive name}`.

And, accordingly, if you want to pass the  `{zip archive destination}` argument first you need to pass the `{zip archive name}` and `{zip archive source}` arguments.

## Examples:
### All arguments are default:
```
EXAMPLE_DISC:\foo\bar>zipthis
```
This command will create archive with name `bar.zip` in `EXAMPLE_DISC:\foo\bar` which will contains all files and directories from `EXAMPLE_DISC:\foo\bar`.

### Set archive name:
```
EXAMPLE_DISC:\foo\bar>zipthis myarchive
```
This command will create archive with name `myarchive.zip` in `EXAMPLE_DISC:\foo\bar` which will contains all files and directories from `EXAMPLE_DISC:\foo\bar`.

###  Set archive source:
```
EXAMPLE_DISC:\foo\bar>zipthis myarchive EXAMPLE_DISC:\foo\bar\johndoe
```
This command will create archive with name `myarchive.zip` in `EXAMPLE_DISC:\foo\bar` which will contains all files and directories from `EXAMPLE_DISC:\foo\bar\johndoe`.

###  Set archive source:
```
EXAMPLE_DISC:\foo\bar>zipthis myarchive EXAMPLE_DISC:\foo\bar\johndoe EXAMPLE_DISC:\foo\
```
This command will create archive with name `myarchive.zip` in `EXAMPLE_DISC:\foo\` which will contains all files and directories from `EXAMPLE_DISC:\foo\bar\johndoe`.
