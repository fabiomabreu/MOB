namespace Target.Mob.Desktop.Sincronizacao.Common.Util;

public interface IRecordSet
{
	bool EOF { get; }

	int RowCount { get; }

	int QuickRowCount { get; }

	bool MoveNext();
}
