#include "Stdafx.h"
#include "Text.h"

using namespace System::Windows::Forms;
using namespace System::Threading;
using namespace System::Diagnostics;

void Core::Text::Text::Send(int interval)
{
	if (!_special)
	{
		for each (auto t in _text)
		{

			Debug::WriteLine(t.ToString());
			SendKeys::Send(t.ToString());
			if (interval > 0)
				Thread::Sleep(interval / _text->Length);
		}
	}
	else
	{
		SendKeys::Send(_text);
	}

}