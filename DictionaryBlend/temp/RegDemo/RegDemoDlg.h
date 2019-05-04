// RegDemoDlg.h : header file
//

#if !defined(AFX_REGDEMODLG_H__C72C13FA_DD81_47CC_8D68_25F57324F3D0__INCLUDED_)
#define AFX_REGDEMODLG_H__C72C13FA_DD81_47CC_8D68_25F57324F3D0__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

/////////////////////////////////////////////////////////////////////////////
// CRegDemoDlg dialog

class CRegDemoDlg : public CDialog
{
// Construction
public:
	CRegDemoDlg(CWnd* pParent = NULL);	// standard constructor

// Dialog Data
	//{{AFX_DATA(CRegDemoDlg)
	enum { IDD = IDD_REGDEMO_DIALOG };
		// NOTE: the ClassWizard will add data members here
	//}}AFX_DATA

	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CRegDemoDlg)
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support
	//}}AFX_VIRTUAL

// Implementation
protected:
	HICON m_hIcon;

	// Generated message map functions
	//{{AFX_MSG(CRegDemoDlg)
	virtual BOOL OnInitDialog();
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_REGDEMODLG_H__C72C13FA_DD81_47CC_8D68_25F57324F3D0__INCLUDED_)
