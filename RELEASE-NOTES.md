# Release Notes

## 2.0.0 - 21 Oct 2019

Breaking changes:
- Removed HelpText from CmdArgInfo, is now public extension method on IList<CmdAllowedArg>

New features:
- (None)

Bug fixes:
- (None)

## 1.2.0 - 19 Oct 2019

Breaking changes:
- (None)

New features:
- Added IsRequired property to CmdAllowedArg.
- CmdArgInfo now checks that all required arguments have been supplied.

Bug fixes:
- (None)


## 1.1.1 - 07 Oct 2019

Breaking changes:
- (None)

New features:
- (None)

Bug fixes:
- Fix so all public types now have XML documentation.


## 1.1.0 - 06 Oct 2019

Breaking changes:
- (None)

New features:
- New Arguments namespace with command line argument handling functionality.

Bug fixes:
- Fix so dont display input key on any key press prompt.
- Fix so XML documentation is provided as part of package.

