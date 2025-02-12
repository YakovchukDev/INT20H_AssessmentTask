--
-- PostgreSQL database dump
--

-- Dumped from database version 17.2
-- Dumped by pg_dump version 17.2

-- Started on 2025-02-12 20:54:51

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET transaction_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 239 (class 1259 OID 16881)
-- Name: Categories; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Categories" (
    "Id" integer NOT NULL,
    "Name" text NOT NULL
);


ALTER TABLE public."Categories" OWNER TO postgres;

--
-- TOC entry 238 (class 1259 OID 16880)
-- Name: Categories_Id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."Categories_Id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."Categories_Id_seq" OWNER TO postgres;

--
-- TOC entry 5015 (class 0 OID 0)
-- Dependencies: 238
-- Name: Categories_Id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."Categories_Id_seq" OWNED BY public."Categories"."Id";


--
-- TOC entry 220 (class 1259 OID 16664)
-- Name: MediaFiles; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."MediaFiles" (
    "Id" integer NOT NULL,
    "FileType" text DEFAULT 'None'::text NOT NULL,
    "FilePath" text NOT NULL
);
ALTER TABLE ONLY public."MediaFiles" ALTER COLUMN "FilePath" SET STORAGE PLAIN;


ALTER TABLE public."MediaFiles" OWNER TO postgres;

--
-- TOC entry 219 (class 1259 OID 16663)
-- Name: MediaFiles_Id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."MediaFiles_Id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."MediaFiles_Id_seq" OWNER TO postgres;

--
-- TOC entry 5016 (class 0 OID 0)
-- Dependencies: 219
-- Name: MediaFiles_Id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."MediaFiles_Id_seq" OWNED BY public."MediaFiles"."Id";


--
-- TOC entry 226 (class 1259 OID 16709)
-- Name: PageElements; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."PageElements" (
    "Id" integer NOT NULL,
    "PageId" integer NOT NULL,
    "ContentType" text DEFAULT 'Text'::text NOT NULL,
    "Content" jsonb,
    "MediaFileId" integer,
    "Order" numeric(4,1) NOT NULL
);


ALTER TABLE public."PageElements" OWNER TO postgres;

--
-- TOC entry 225 (class 1259 OID 16708)
-- Name: PageElements_Id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."PageElements_Id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."PageElements_Id_seq" OWNER TO postgres;

--
-- TOC entry 5017 (class 0 OID 0)
-- Dependencies: 225
-- Name: PageElements_Id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."PageElements_Id_seq" OWNED BY public."PageElements"."Id";


--
-- TOC entry 224 (class 1259 OID 16695)
-- Name: Pages; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Pages" (
    "Id" integer NOT NULL,
    "QuestId" integer NOT NULL,
    "PageNumber" integer NOT NULL,
    "Title" text
);


ALTER TABLE public."Pages" OWNER TO postgres;

--
-- TOC entry 223 (class 1259 OID 16694)
-- Name: Pages_Id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."Pages_Id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."Pages_Id_seq" OWNER TO postgres;

--
-- TOC entry 5018 (class 0 OID 0)
-- Dependencies: 223
-- Name: Pages_Id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."Pages_Id_seq" OWNED BY public."Pages"."Id";


--
-- TOC entry 228 (class 1259 OID 16729)
-- Name: QuestRatings; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."QuestRatings" (
    "Id" integer NOT NULL,
    "QuestId" integer NOT NULL,
    "UserId" integer NOT NULL,
    "Rating" integer,
    "Review" text,
    CONSTRAINT "QuestRatings_Rating_check" CHECK ((("Rating" >= 1) AND ("Rating" <= 5)))
);


ALTER TABLE public."QuestRatings" OWNER TO postgres;

--
-- TOC entry 227 (class 1259 OID 16728)
-- Name: QuestRatings_Id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."QuestRatings_Id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."QuestRatings_Id_seq" OWNER TO postgres;

--
-- TOC entry 5019 (class 0 OID 0)
-- Dependencies: 227
-- Name: QuestRatings_Id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."QuestRatings_Id_seq" OWNED BY public."QuestRatings"."Id";


--
-- TOC entry 236 (class 1259 OID 16841)
-- Name: QuestTasks; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."QuestTasks" (
    "Id" integer NOT NULL,
    "PageId" integer NOT NULL,
    "TaskDescription" text NOT NULL,
    "ResponseTypeId" integer NOT NULL
);


ALTER TABLE public."QuestTasks" OWNER TO postgres;

--
-- TOC entry 241 (class 1259 OID 16907)
-- Name: QuestTexts; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."QuestTexts" (
    "Id" integer NOT NULL,
    "Text" text NOT NULL,
    "Color" text NOT NULL
);


ALTER TABLE public."QuestTexts" OWNER TO postgres;

--
-- TOC entry 240 (class 1259 OID 16906)
-- Name: QuestText_Id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."QuestText_Id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."QuestText_Id_seq" OWNER TO postgres;

--
-- TOC entry 5020 (class 0 OID 0)
-- Dependencies: 240
-- Name: QuestText_Id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."QuestText_Id_seq" OWNED BY public."QuestTexts"."Id";


--
-- TOC entry 222 (class 1259 OID 16673)
-- Name: Quests; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Quests" (
    "Id" integer NOT NULL,
    "AuthorId" integer NOT NULL,
    "Rating" numeric(3,2),
    "CreatedAt" timestamp without time zone DEFAULT now() NOT NULL,
    "UpdatedAt" timestamp without time zone DEFAULT now(),
    "PreviewMediaFileId" integer NOT NULL,
    "Timer" interval,
    "CategoryId" integer NOT NULL,
    "Participants" integer DEFAULT 1 NOT NULL,
    "Difficulty" integer NOT NULL,
    "Tags" text[],
    "TitleId" integer NOT NULL,
    "DescriptionId" integer NOT NULL,
    "Visible" boolean DEFAULT false NOT NULL
);


ALTER TABLE public."Quests" OWNER TO postgres;

--
-- TOC entry 221 (class 1259 OID 16672)
-- Name: Quests_Id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."Quests_Id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."Quests_Id_seq" OWNER TO postgres;

--
-- TOC entry 5021 (class 0 OID 0)
-- Dependencies: 221
-- Name: Quests_Id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."Quests_Id_seq" OWNED BY public."Quests"."Id";


--
-- TOC entry 243 (class 1259 OID 16950)
-- Name: RefreshToken; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."RefreshToken" (
    "Id" integer NOT NULL,
    "UserId" integer NOT NULL,
    "Token" text NOT NULL,
    "ExpiryDate" date NOT NULL
);


ALTER TABLE public."RefreshToken" OWNER TO postgres;

--
-- TOC entry 242 (class 1259 OID 16949)
-- Name: RefreshToken_Id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."RefreshToken_Id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."RefreshToken_Id_seq" OWNER TO postgres;

--
-- TOC entry 5022 (class 0 OID 0)
-- Dependencies: 242
-- Name: RefreshToken_Id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."RefreshToken_Id_seq" OWNED BY public."RefreshToken"."Id";


--
-- TOC entry 232 (class 1259 OID 16806)
-- Name: TaskResponseTypes; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."TaskResponseTypes" (
    "Id" integer NOT NULL,
    "ResponseType" text DEFAULT 'Text'::text
);


ALTER TABLE public."TaskResponseTypes" OWNER TO postgres;

--
-- TOC entry 231 (class 1259 OID 16805)
-- Name: ResponseTypes_Id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."ResponseTypes_Id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."ResponseTypes_Id_seq" OWNER TO postgres;

--
-- TOC entry 5023 (class 0 OID 0)
-- Dependencies: 231
-- Name: ResponseTypes_Id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."ResponseTypes_Id_seq" OWNED BY public."TaskResponseTypes"."Id";


--
-- TOC entry 234 (class 1259 OID 16817)
-- Name: TaskOptions; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."TaskOptions" (
    "Id" integer NOT NULL,
    "TaskId" integer NOT NULL,
    "OptionText" text NOT NULL
);


ALTER TABLE public."TaskOptions" OWNER TO postgres;

--
-- TOC entry 233 (class 1259 OID 16816)
-- Name: TaskOptions_Id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."TaskOptions_Id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."TaskOptions_Id_seq" OWNER TO postgres;

--
-- TOC entry 5024 (class 0 OID 0)
-- Dependencies: 233
-- Name: TaskOptions_Id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."TaskOptions_Id_seq" OWNED BY public."TaskOptions"."Id";


--
-- TOC entry 237 (class 1259 OID 16859)
-- Name: TaskResponses; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."TaskResponses" (
    "Id" integer NOT NULL,
    "TaskId" integer NOT NULL,
    "ResponseTypeId" integer NOT NULL,
    "Answer " text NOT NULL,
    "AdditionalData " text
);


ALTER TABLE public."TaskResponses" OWNER TO postgres;

--
-- TOC entry 235 (class 1259 OID 16840)
-- Name: Tasks_Id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."Tasks_Id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."Tasks_Id_seq" OWNER TO postgres;

--
-- TOC entry 5025 (class 0 OID 0)
-- Dependencies: 235
-- Name: Tasks_Id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."Tasks_Id_seq" OWNED BY public."QuestTasks"."Id";


--
-- TOC entry 230 (class 1259 OID 16779)
-- Name: UserQuestHistory; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."UserQuestHistory" (
    "Id" integer NOT NULL,
    "UserId" integer NOT NULL,
    "QuestId" integer NOT NULL,
    "Status" text DEFAULT 'InProgress'::text NOT NULL,
    "TimeSpent" interval NOT NULL,
    "Step" integer DEFAULT 1 NOT NULL
);
ALTER TABLE ONLY public."UserQuestHistory" ALTER COLUMN "Status" SET STORAGE PLAIN;


ALTER TABLE public."UserQuestHistory" OWNER TO postgres;

--
-- TOC entry 229 (class 1259 OID 16778)
-- Name: UserQuestHistory_Id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."UserQuestHistory_Id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."UserQuestHistory_Id_seq" OWNER TO postgres;

--
-- TOC entry 5026 (class 0 OID 0)
-- Dependencies: 229
-- Name: UserQuestHistory_Id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."UserQuestHistory_Id_seq" OWNED BY public."UserQuestHistory"."Id";


--
-- TOC entry 218 (class 1259 OID 16650)
-- Name: Users; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Users" (
    "Id" integer NOT NULL,
    "Name" text NOT NULL,
    "Username" text NOT NULL,
    "Email" text NOT NULL,
    "PasswordHash" text NOT NULL,
    "CreatedAt" timestamp without time zone DEFAULT now() NOT NULL,
    "Role" text DEFAULT 'User'::text NOT NULL,
    "AvatarPath" text,
    "AboutMe" text,
    "Rating" numeric(3,2),
    "RefreshTokenIds" integer[]
);
ALTER TABLE ONLY public."Users" ALTER COLUMN "AvatarPath" SET STORAGE PLAIN;


ALTER TABLE public."Users" OWNER TO postgres;

--
-- TOC entry 217 (class 1259 OID 16649)
-- Name: Users_Id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."Users_Id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."Users_Id_seq" OWNER TO postgres;

--
-- TOC entry 5027 (class 0 OID 0)
-- Dependencies: 217
-- Name: Users_Id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."Users_Id_seq" OWNED BY public."Users"."Id";


--
-- TOC entry 4780 (class 2604 OID 16884)
-- Name: Categories Id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Categories" ALTER COLUMN "Id" SET DEFAULT nextval('public."Categories_Id_seq"'::regclass);


--
-- TOC entry 4762 (class 2604 OID 16667)
-- Name: MediaFiles Id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."MediaFiles" ALTER COLUMN "Id" SET DEFAULT nextval('public."MediaFiles_Id_seq"'::regclass);


--
-- TOC entry 4770 (class 2604 OID 16712)
-- Name: PageElements Id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."PageElements" ALTER COLUMN "Id" SET DEFAULT nextval('public."PageElements_Id_seq"'::regclass);


--
-- TOC entry 4769 (class 2604 OID 16698)
-- Name: Pages Id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Pages" ALTER COLUMN "Id" SET DEFAULT nextval('public."Pages_Id_seq"'::regclass);


--
-- TOC entry 4772 (class 2604 OID 16732)
-- Name: QuestRatings Id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."QuestRatings" ALTER COLUMN "Id" SET DEFAULT nextval('public."QuestRatings_Id_seq"'::regclass);


--
-- TOC entry 4779 (class 2604 OID 16844)
-- Name: QuestTasks Id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."QuestTasks" ALTER COLUMN "Id" SET DEFAULT nextval('public."Tasks_Id_seq"'::regclass);


--
-- TOC entry 4781 (class 2604 OID 16910)
-- Name: QuestTexts Id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."QuestTexts" ALTER COLUMN "Id" SET DEFAULT nextval('public."QuestText_Id_seq"'::regclass);


--
-- TOC entry 4764 (class 2604 OID 16676)
-- Name: Quests Id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Quests" ALTER COLUMN "Id" SET DEFAULT nextval('public."Quests_Id_seq"'::regclass);


--
-- TOC entry 4782 (class 2604 OID 16953)
-- Name: RefreshToken Id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RefreshToken" ALTER COLUMN "Id" SET DEFAULT nextval('public."RefreshToken_Id_seq"'::regclass);


--
-- TOC entry 4778 (class 2604 OID 16820)
-- Name: TaskOptions Id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."TaskOptions" ALTER COLUMN "Id" SET DEFAULT nextval('public."TaskOptions_Id_seq"'::regclass);


--
-- TOC entry 4776 (class 2604 OID 16809)
-- Name: TaskResponseTypes Id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."TaskResponseTypes" ALTER COLUMN "Id" SET DEFAULT nextval('public."ResponseTypes_Id_seq"'::regclass);


--
-- TOC entry 4773 (class 2604 OID 16782)
-- Name: UserQuestHistory Id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."UserQuestHistory" ALTER COLUMN "Id" SET DEFAULT nextval('public."UserQuestHistory_Id_seq"'::regclass);


--
-- TOC entry 4759 (class 2604 OID 16653)
-- Name: Users Id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Users" ALTER COLUMN "Id" SET DEFAULT nextval('public."Users_Id_seq"'::regclass);


--
-- TOC entry 5005 (class 0 OID 16881)
-- Dependencies: 239
-- Data for Name: Categories; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Categories" ("Id", "Name") FROM stdin;
\.


--
-- TOC entry 4986 (class 0 OID 16664)
-- Dependencies: 220
-- Data for Name: MediaFiles; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."MediaFiles" ("Id", "FileType", "FilePath") FROM stdin;
8	Image	D:\\Reposetories\\INT20H_AssessmentTask\\QuestPlatform.Server\\wwwroot\\Previews\\006..jpg
9	Image	D:\\Reposetories\\INT20H_AssessmentTask\\QuestPlatform.Server\\wwwroot\\Previews\\003..png
\.


--
-- TOC entry 4992 (class 0 OID 16709)
-- Dependencies: 226
-- Data for Name: PageElements; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."PageElements" ("Id", "PageId", "ContentType", "Content", "MediaFileId", "Order") FROM stdin;
\.


--
-- TOC entry 4990 (class 0 OID 16695)
-- Dependencies: 224
-- Data for Name: Pages; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Pages" ("Id", "QuestId", "PageNumber", "Title") FROM stdin;
\.


--
-- TOC entry 4994 (class 0 OID 16729)
-- Dependencies: 228
-- Data for Name: QuestRatings; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."QuestRatings" ("Id", "QuestId", "UserId", "Rating", "Review") FROM stdin;
\.


--
-- TOC entry 5002 (class 0 OID 16841)
-- Dependencies: 236
-- Data for Name: QuestTasks; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."QuestTasks" ("Id", "PageId", "TaskDescription", "ResponseTypeId") FROM stdin;
\.


--
-- TOC entry 5007 (class 0 OID 16907)
-- Dependencies: 241
-- Data for Name: QuestTexts; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."QuestTexts" ("Id", "Text", "Color") FROM stdin;
\.


--
-- TOC entry 4988 (class 0 OID 16673)
-- Dependencies: 222
-- Data for Name: Quests; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Quests" ("Id", "AuthorId", "Rating", "CreatedAt", "UpdatedAt", "PreviewMediaFileId", "Timer", "CategoryId", "Participants", "Difficulty", "Tags", "TitleId", "DescriptionId", "Visible") FROM stdin;
\.


--
-- TOC entry 5009 (class 0 OID 16950)
-- Dependencies: 243
-- Data for Name: RefreshToken; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."RefreshToken" ("Id", "UserId", "Token", "ExpiryDate") FROM stdin;
\.


--
-- TOC entry 5000 (class 0 OID 16817)
-- Dependencies: 234
-- Data for Name: TaskOptions; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."TaskOptions" ("Id", "TaskId", "OptionText") FROM stdin;
\.


--
-- TOC entry 4998 (class 0 OID 16806)
-- Dependencies: 232
-- Data for Name: TaskResponseTypes; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."TaskResponseTypes" ("Id", "ResponseType") FROM stdin;
\.


--
-- TOC entry 5003 (class 0 OID 16859)
-- Dependencies: 237
-- Data for Name: TaskResponses; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."TaskResponses" ("Id", "TaskId", "ResponseTypeId", "Answer ", "AdditionalData ") FROM stdin;
\.


--
-- TOC entry 4996 (class 0 OID 16779)
-- Dependencies: 230
-- Data for Name: UserQuestHistory; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."UserQuestHistory" ("Id", "UserId", "QuestId", "Status", "TimeSpent", "Step") FROM stdin;
\.


--
-- TOC entry 4984 (class 0 OID 16650)
-- Dependencies: 218
-- Data for Name: Users; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Users" ("Id", "Name", "Username", "Email", "PasswordHash", "CreatedAt", "Role", "AvatarPath", "AboutMe", "Rating", "RefreshTokenIds") FROM stdin;
\.


--
-- TOC entry 5028 (class 0 OID 0)
-- Dependencies: 238
-- Name: Categories_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Categories_Id_seq"', 8, true);


--
-- TOC entry 5029 (class 0 OID 0)
-- Dependencies: 219
-- Name: MediaFiles_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."MediaFiles_Id_seq"', 9, true);


--
-- TOC entry 5030 (class 0 OID 0)
-- Dependencies: 225
-- Name: PageElements_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."PageElements_Id_seq"', 1, false);


--
-- TOC entry 5031 (class 0 OID 0)
-- Dependencies: 223
-- Name: Pages_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Pages_Id_seq"', 1, false);


--
-- TOC entry 5032 (class 0 OID 0)
-- Dependencies: 227
-- Name: QuestRatings_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."QuestRatings_Id_seq"', 1, false);


--
-- TOC entry 5033 (class 0 OID 0)
-- Dependencies: 240
-- Name: QuestText_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."QuestText_Id_seq"', 12, true);


--
-- TOC entry 5034 (class 0 OID 0)
-- Dependencies: 221
-- Name: Quests_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Quests_Id_seq"', 4, true);


--
-- TOC entry 5035 (class 0 OID 0)
-- Dependencies: 242
-- Name: RefreshToken_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."RefreshToken_Id_seq"', 1, false);


--
-- TOC entry 5036 (class 0 OID 0)
-- Dependencies: 231
-- Name: ResponseTypes_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."ResponseTypes_Id_seq"', 1, false);


--
-- TOC entry 5037 (class 0 OID 0)
-- Dependencies: 233
-- Name: TaskOptions_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."TaskOptions_Id_seq"', 1, false);


--
-- TOC entry 5038 (class 0 OID 0)
-- Dependencies: 235
-- Name: Tasks_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Tasks_Id_seq"', 1, false);


--
-- TOC entry 5039 (class 0 OID 0)
-- Dependencies: 229
-- Name: UserQuestHistory_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."UserQuestHistory_Id_seq"', 1, false);


--
-- TOC entry 5040 (class 0 OID 0)
-- Dependencies: 217
-- Name: Users_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Users_Id_seq"', 6, true);


--
-- TOC entry 4815 (class 2606 OID 16888)
-- Name: Categories Categories_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Categories"
    ADD CONSTRAINT "Categories_pkey" PRIMARY KEY ("Id");


--
-- TOC entry 4791 (class 2606 OID 16671)
-- Name: MediaFiles MediaFiles_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."MediaFiles"
    ADD CONSTRAINT "MediaFiles_pkey" PRIMARY KEY ("Id");


--
-- TOC entry 4797 (class 2606 OID 16717)
-- Name: PageElements PageElements_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."PageElements"
    ADD CONSTRAINT "PageElements_pkey" PRIMARY KEY ("Id");


--
-- TOC entry 4795 (class 2606 OID 16702)
-- Name: Pages Pages_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Pages"
    ADD CONSTRAINT "Pages_pkey" PRIMARY KEY ("Id");


--
-- TOC entry 4799 (class 2606 OID 16737)
-- Name: QuestRatings QuestRatings_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."QuestRatings"
    ADD CONSTRAINT "QuestRatings_pkey" PRIMARY KEY ("Id");


--
-- TOC entry 4819 (class 2606 OID 16915)
-- Name: QuestTexts QuestText_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."QuestTexts"
    ADD CONSTRAINT "QuestText_pkey" PRIMARY KEY ("Id");


--
-- TOC entry 4793 (class 2606 OID 16683)
-- Name: Quests Quests_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Quests"
    ADD CONSTRAINT "Quests_pkey" PRIMARY KEY ("Id");


--
-- TOC entry 4821 (class 2606 OID 16957)
-- Name: RefreshToken RefreshToken_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RefreshToken"
    ADD CONSTRAINT "RefreshToken_pkey" PRIMARY KEY ("Id");


--
-- TOC entry 4805 (class 2606 OID 16813)
-- Name: TaskResponseTypes ResponseTypes_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."TaskResponseTypes"
    ADD CONSTRAINT "ResponseTypes_pkey" PRIMARY KEY ("Id");


--
-- TOC entry 4807 (class 2606 OID 16825)
-- Name: TaskOptions TaskOptions_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."TaskOptions"
    ADD CONSTRAINT "TaskOptions_pkey" PRIMARY KEY ("Id");


--
-- TOC entry 4811 (class 2606 OID 16865)
-- Name: TaskResponses TaskResponses_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."TaskResponses"
    ADD CONSTRAINT "TaskResponses_pkey" PRIMARY KEY ("Id");


--
-- TOC entry 4809 (class 2606 OID 16848)
-- Name: QuestTasks Tasks_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."QuestTasks"
    ADD CONSTRAINT "Tasks_pkey" PRIMARY KEY ("Id");


--
-- TOC entry 4801 (class 2606 OID 16784)
-- Name: UserQuestHistory UserQuestHistory_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."UserQuestHistory"
    ADD CONSTRAINT "UserQuestHistory_pkey" PRIMARY KEY ("Id");


--
-- TOC entry 4785 (class 2606 OID 16662)
-- Name: Users Users_Email_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Users"
    ADD CONSTRAINT "Users_Email_key" UNIQUE ("Email");


--
-- TOC entry 4787 (class 2606 OID 16660)
-- Name: Users Users_Username_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Users"
    ADD CONSTRAINT "Users_Username_key" UNIQUE ("Username");


--
-- TOC entry 4789 (class 2606 OID 16658)
-- Name: Users Users_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Users"
    ADD CONSTRAINT "Users_pkey" PRIMARY KEY ("Id");


--
-- TOC entry 4817 (class 2606 OID 16947)
-- Name: Categories category-uq; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Categories"
    ADD CONSTRAINT "category-uq" UNIQUE ("Name");


--
-- TOC entry 4813 (class 2606 OID 16867)
-- Name: TaskResponses uq_task_response; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."TaskResponses"
    ADD CONSTRAINT uq_task_response UNIQUE ("TaskId");


--
-- TOC entry 4803 (class 2606 OID 16786)
-- Name: UserQuestHistory uq_user_quest; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."UserQuestHistory"
    ADD CONSTRAINT uq_user_quest UNIQUE ("UserId", "QuestId");


--
-- TOC entry 4828 (class 2606 OID 16723)
-- Name: PageElements PageElements_MediaFileId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."PageElements"
    ADD CONSTRAINT "PageElements_MediaFileId_fkey" FOREIGN KEY ("MediaFileId") REFERENCES public."MediaFiles"("Id") ON DELETE SET NULL;


--
-- TOC entry 4829 (class 2606 OID 16718)
-- Name: PageElements PageElements_PageId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."PageElements"
    ADD CONSTRAINT "PageElements_PageId_fkey" FOREIGN KEY ("PageId") REFERENCES public."Pages"("Id") ON DELETE CASCADE;


--
-- TOC entry 4827 (class 2606 OID 16703)
-- Name: Pages Pages_QuestId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Pages"
    ADD CONSTRAINT "Pages_QuestId_fkey" FOREIGN KEY ("QuestId") REFERENCES public."Quests"("Id") ON DELETE CASCADE;


--
-- TOC entry 4830 (class 2606 OID 16738)
-- Name: QuestRatings QuestRatings_QuestId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."QuestRatings"
    ADD CONSTRAINT "QuestRatings_QuestId_fkey" FOREIGN KEY ("QuestId") REFERENCES public."Quests"("Id") ON DELETE CASCADE;


--
-- TOC entry 4831 (class 2606 OID 16743)
-- Name: QuestRatings QuestRatings_UserId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."QuestRatings"
    ADD CONSTRAINT "QuestRatings_UserId_fkey" FOREIGN KEY ("UserId") REFERENCES public."Users"("Id") ON DELETE CASCADE;


--
-- TOC entry 4822 (class 2606 OID 16684)
-- Name: Quests Quests_AuthorId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Quests"
    ADD CONSTRAINT "Quests_AuthorId_fkey" FOREIGN KEY ("AuthorId") REFERENCES public."Users"("Id") ON DELETE CASCADE;


--
-- TOC entry 4823 (class 2606 OID 16923)
-- Name: Quests Quests_CategoryId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Quests"
    ADD CONSTRAINT "Quests_CategoryId_fkey" FOREIGN KEY ("CategoryId") REFERENCES public."Categories"("Id") NOT VALID;


--
-- TOC entry 4824 (class 2606 OID 16933)
-- Name: Quests Quests_DesctiptionId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Quests"
    ADD CONSTRAINT "Quests_DesctiptionId_fkey" FOREIGN KEY ("DescriptionId") REFERENCES public."QuestTexts"("Id") NOT VALID;


--
-- TOC entry 4825 (class 2606 OID 16689)
-- Name: Quests Quests_PreviewMediaFileId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Quests"
    ADD CONSTRAINT "Quests_PreviewMediaFileId_fkey" FOREIGN KEY ("PreviewMediaFileId") REFERENCES public."MediaFiles"("Id");


--
-- TOC entry 4826 (class 2606 OID 16928)
-- Name: Quests Quests_TitleId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Quests"
    ADD CONSTRAINT "Quests_TitleId_fkey" FOREIGN KEY ("TitleId") REFERENCES public."QuestTexts"("Id") NOT VALID;


--
-- TOC entry 4834 (class 2606 OID 16849)
-- Name: QuestTasks fk_page_id; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."QuestTasks"
    ADD CONSTRAINT fk_page_id FOREIGN KEY ("PageId") REFERENCES public."Pages"("Id");


--
-- TOC entry 4832 (class 2606 OID 16792)
-- Name: UserQuestHistory fk_quest_id; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."UserQuestHistory"
    ADD CONSTRAINT fk_quest_id FOREIGN KEY ("QuestId") REFERENCES public."Quests"("Id") ON DELETE CASCADE;


--
-- TOC entry 4835 (class 2606 OID 16854)
-- Name: QuestTasks fk_response_type_id; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."QuestTasks"
    ADD CONSTRAINT fk_response_type_id FOREIGN KEY ("ResponseTypeId") REFERENCES public."TaskResponseTypes"("Id");


--
-- TOC entry 4836 (class 2606 OID 16868)
-- Name: TaskResponses fk_response_type_id; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."TaskResponses"
    ADD CONSTRAINT fk_response_type_id FOREIGN KEY ("ResponseTypeId") REFERENCES public."TaskResponseTypes"("Id");


--
-- TOC entry 4837 (class 2606 OID 16873)
-- Name: TaskResponses fk_task_id; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."TaskResponses"
    ADD CONSTRAINT fk_task_id FOREIGN KEY ("TaskId") REFERENCES public."QuestTasks"("Id");


--
-- TOC entry 4833 (class 2606 OID 16787)
-- Name: UserQuestHistory fk_user_id; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."UserQuestHistory"
    ADD CONSTRAINT fk_user_id FOREIGN KEY ("UserId") REFERENCES public."Users"("Id") ON DELETE CASCADE;


-- Completed on 2025-02-12 20:54:51

--
-- PostgreSQL database dump complete
--

