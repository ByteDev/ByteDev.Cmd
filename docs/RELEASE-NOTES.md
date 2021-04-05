# Release Notes

## 5.0.0 - 05 April 2021

Breaking changes:
- `CmdAllowedArg.LongName` can only contain `[A-Za-z]`.
- `CmdAllowedArg.ShortName` can only contain `[A-Za-z]`.

New features:
- Added `CmdArgInfo.HasArgument`.

Bug fixes / internal changes:
- (None)

## 4.2.2 - 31 March 2021

Breaking changes:
- (None)

New features:
- (None)

Bug fixes / internal changes:
- Fix so same arg supplied more than once is caught.

## 4.2.1 - 14 December 2020

Breaking changes:
- (None)

New features:
- (None)

Bug fixes / internal changes:
- Package build fixes.

## 4.2.0 - 14 December 2020

Breaking changes:
- (None)

New features:
- Added `Output.WriteWrap`.

Bug fixes / internal changes:
- Fixed `Output.WriteLine(char)`.
- Added missing overloads to `Output` class and removed default/optional params.

## 4.1.1 - 12 April 2020

Breaking changes:
- (None)

New features:
- (None)

Bug fixes / internal changes:
- Added .NET Standard package dependency.

## 4.1.0 - 05 December 2019

Breaking changes:
- (None)

New features:
- Added `Output.Write(UnorderedList)`.
- Added `Output.Write(OrderedList)`.

Bug fixes / internal changes:
- `OutputColor` now uses `Console.BackgroundColor` if not specified.
- Changed internal rainbow color set.

## 4.0.0 - 08 November 2019

Breaking changes:
- Table classes now under `ByteDev.Cmd.Tables` namespace.
- `TablePosition` is now `CellPosition`.

New features:
- Added new border style.
- Added `Cell` (Table now holds Cells type not strings)

Bug fixes / internal changes:
- (None)

## 3.1.0 - 06 November 2019

Breaking changes:
- (None)

New features:
- Added `CmdArgInfo.GetArgument(char)`.
- Added `CmdArgInfo.GetArgument(string)`.
- Added `Table.UpdateRow` overload.

Bug fixes / internal changes:
- Fixed null color handling.

## 3.0.1 - 05 November 2019

Breaking changes:
- (None)

New features:
- (None)

Bug fixes / internal changes:
- Fix around retrieving Table rows and columns.

## 3.0.0 - 05 November 2019

Breaking changes:
- Renamed `Table.GetValue` to `GetCell`
- Renamed `Table.InsertValue` to `UpdateCell`
- TablePosition X is now Column.
- TablePosition Y is now Rows.

New features:
- Added `Table.UpdateRow`.
- Added `Table.GetRow`.
- Added `Table.GetColumn`.

Bug fixes / internal changes:
- (None)

## 2.1.0 - 04 November 2019

Breaking changes:
- (None)

New features:
- Added concept of `BorderStyle` (`IBorderStyle`, `BorderSingle`, `BorderDouble` classes)
- Added `MessagBox.BorderStyle` property.
- Added `Table` class and the ability to write it in the `Output` class.
- Added `Output.Write(char)`
- Added `Output.WriteLine(char)`

Bug fixes / internal changes:
- (None)

## 2.0.0 - 21 October 2019

Breaking changes:
- Removed `CmdArgInfo.HelpText`, is now public extension method on `IList<CmdAllowedArg>`

New features:
- (None)

Bug fixes / internal changes:
- (None)

## 1.2.0 - 19 October 2019

Breaking changes:
- (None)

New features:
- Added `CmdAllowedArg.IsRequired` property.
- `CmdArgInfo` now checks that all required arguments have been supplied.

Bug fixes / internal changes:
- (None)

## 1.1.1 - 07 October 2019

Breaking changes:
- (None)

New features:
- (None)

Bug fixes / internal changes:
- Fix so all public types now have XML documentation.

## 1.1.0 - 06 October 2019

Breaking changes:
- (None)

New features:
- New `Arguments` namespace with command line argument handling functionality.

Bug fixes / internal changes:
- Fix so dont display input key on any key press prompt.
- Fix so XML documentation is provided as part of package.

