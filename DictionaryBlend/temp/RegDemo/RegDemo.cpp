// RegDemo.cpp : Defines the class behaviors for the application.
//

#include "stdafx.h"
#include "RegDemo.h"
#include "RegDemoDlg.h"
#include "RegDialog.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CRegDemoApp

BEGIN_MESSAGE_MAP(CRegDemoApp, CWinApp)
	//{{AFX_MSG_MAP(CRegDemoApp)
	//}}AFX_MSG
	ON_COMMAND(ID_HELP, CWinApp::OnHelp)
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CRegDemoApp construction

CRegDemoApp::CRegDemoApp()
{
}

/////////////////////////////////////////////////////////////////////////////
// The one and only CRegDemoApp object

CRegDemoApp theApp;

/////////////////////////////////////////////////////////////////////////////
// CRegDemoApp initialization

BOOL CRegDemoApp::InitInstance()
{
	// Standard initialization

#ifdef _AFXDLL
	Enable3dControls();			// Call this when using MFC in a shared DLL
#else
	Enable3dControlsStatic();	// Call this when linking to MFC statically
#endif

	SetRegistryKey(_T("MyCompany"));
	CRegDialog RegistrationDialog;	
	RegistrationDialog.Check();	

	CRegDemoDlg dlg;
	m_pMainWnd = &dlg;
	int nResponse = dlg.DoModal();
	if (nResponse == IDOK)
	{
	}
	else if (nResponse == IDCANCEL)
	{
	}

	// Since the dialog has been closed, return FALSE so that we exit the
	//  application, rather than start the application's message pump.
	return FALSE;
}
