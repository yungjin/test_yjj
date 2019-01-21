create table Member(
	mNo int not null AUTO_INCREMENT, /* PK */
	mId varchar(30) not null,        /* ���̵� */
	mPass varchar(16) not null,      /* ��й�ȣ */
	mName varchar(10) not null,      /* ����� �̸� */
	delYn varchar(1) not null DEFAULT 'N',
	regDate DATETIME not null DEFAULT CURRENT_TIMESTAMP,
	modDate DATETIME not null DEFAULT CURRENT_TIMESTAMP,
	PRIMARY KEY (`mNo`)
)
;

create table Notice(
	nNo int not null AUTO_INCREMENT, /* PK */
	mNo int not null,                /* FK �Է��� �����  */
	nTitle varchar(30) not null,     /* ���� */
	nContents varchar(200) not null, /* ���� */
	delYn varchar(1) not null DEFAULT 'N',
	regDate DATETIME not null DEFAULT CURRENT_TIMESTAMP,
	modDate DATETIME not null DEFAULT CURRENT_TIMESTAMP,
	PRIMARY KEY (`nNo`),
	INDEX FK_Notice_Member (mNo),
	CONSTRAINT FK_Notice_Member FOREIGN KEY (mNo) REFERENCES Member (mNo)
)
;