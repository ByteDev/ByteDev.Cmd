# Release Notes

## 3.0.0 - ?

Breaking changes:
- Table GetValue is now GetCell
- Table InsertValue is now UpdateCell
- TablePosition X is now Column.
- TablePosition Y is now Rows.

New features:
- Added Table.UpdateRow.
- Added Table.GetRow.

Bug fixes:
- (None)


## 2.1.0 - 04 Nov 2019

Breaking changes:
- (None)

New features:
- Added concept of BorderStyle (IBorderStyle, BorderSingle, BorderDouble classes)
- Added MessagBox.BorderStyle property.
- Added Table class and the ability to write it in the Output class.
- Added Output.Write(char)
- Added Output.WriteLine(char)

Bug fixes:
- (None)

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

