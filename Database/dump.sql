--
-- PostgreSQL database dump
--

-- Dumped from database version 17.2
-- Dumped by pg_dump version 17.2

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
-- Name: MediaFiles; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."MediaFiles" (
    "Id" integer NOT NULL,
    "FileName" text NOT NULL,
    "FileType" text DEFAULT 'None'::text NOT NULL,
    "Data" bytea NOT NULL
);


ALTER TABLE public."MediaFiles" OWNER TO postgres;

--
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
-- Name: MediaFiles_Id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."MediaFiles_Id_seq" OWNED BY public."MediaFiles"."Id";


--
-- Name: PageElements; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."PageElements" (
    "Id" integer NOT NULL,
    "PageId" integer NOT NULL,
    "Type" text NOT NULL,
    "Content" jsonb,
    "MediaFileId" integer,
    "Order" integer NOT NULL,
    "Alignment" text DEFAULT 'Full'::text
);


ALTER TABLE public."PageElements" OWNER TO postgres;

--
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
-- Name: PageElements_Id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."PageElements_Id_seq" OWNED BY public."PageElements"."Id";


--
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
-- Name: Pages_Id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."Pages_Id_seq" OWNED BY public."Pages"."Id";


--
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
-- Name: QuestRatings_Id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."QuestRatings_Id_seq" OWNED BY public."QuestRatings"."Id";


--
-- Name: Quests; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Quests" (
    "Id" integer NOT NULL,
    "Title" text NOT NULL,
    "Description" text NOT NULL,
    "AuthorId" integer NOT NULL,
    "Rating" numeric(3,2) DEFAULT 0.0,
    "CreatedAt" timestamp without time zone DEFAULT now(),
    "UpdatedAt" timestamp without time zone DEFAULT now(),
    "PreviewMediaFileId" integer NOT NULL
);


ALTER TABLE public."Quests" OWNER TO postgres;

--
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
-- Name: Quests_Id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."Quests_Id_seq" OWNED BY public."Quests"."Id";


--
-- Name: Users; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Users" (
    "Id" integer NOT NULL,
    "Name" text NOT NULL,
    "Username" text NOT NULL,
    "Email" text NOT NULL,
    "PasswordHash" text NOT NULL,
    "CreatedAt" timestamp without time zone DEFAULT now(),
    "Role" text DEFAULT 'User'::text
);


ALTER TABLE public."Users" OWNER TO postgres;

--
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
-- Name: Users_Id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."Users_Id_seq" OWNED BY public."Users"."Id";


--
-- Name: MediaFiles Id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."MediaFiles" ALTER COLUMN "Id" SET DEFAULT nextval('public."MediaFiles_Id_seq"'::regclass);


--
-- Name: PageElements Id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."PageElements" ALTER COLUMN "Id" SET DEFAULT nextval('public."PageElements_Id_seq"'::regclass);


--
-- Name: Pages Id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Pages" ALTER COLUMN "Id" SET DEFAULT nextval('public."Pages_Id_seq"'::regclass);


--
-- Name: QuestRatings Id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."QuestRatings" ALTER COLUMN "Id" SET DEFAULT nextval('public."QuestRatings_Id_seq"'::regclass);


--
-- Name: Quests Id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Quests" ALTER COLUMN "Id" SET DEFAULT nextval('public."Quests_Id_seq"'::regclass);


--
-- Name: Users Id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Users" ALTER COLUMN "Id" SET DEFAULT nextval('public."Users_Id_seq"'::regclass);


--
-- Data for Name: MediaFiles; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."MediaFiles" ("Id", "FileName", "FileType", "Data") FROM stdin;
\.


--
-- Data for Name: PageElements; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."PageElements" ("Id", "PageId", "Type", "Content", "MediaFileId", "Order", "Alignment") FROM stdin;
\.


--
-- Data for Name: Pages; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Pages" ("Id", "QuestId", "PageNumber", "Title") FROM stdin;
\.


--
-- Data for Name: QuestRatings; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."QuestRatings" ("Id", "QuestId", "UserId", "Rating", "Review") FROM stdin;
\.


--
-- Data for Name: Quests; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Quests" ("Id", "Title", "Description", "AuthorId", "Rating", "CreatedAt", "UpdatedAt", "PreviewMediaFileId") FROM stdin;
\.


--
-- Name: MediaFiles_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."MediaFiles_Id_seq"', 1, false);


--
-- Name: PageElements_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."PageElements_Id_seq"', 1, false);


--
-- Name: Pages_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Pages_Id_seq"', 1, false);


--
-- Name: QuestRatings_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."QuestRatings_Id_seq"', 1, false);


--
-- Name: Quests_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Quests_Id_seq"', 1, false);


--
-- Name: Users_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Users_Id_seq"', 3, true);


--
-- Name: MediaFiles MediaFiles_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."MediaFiles"
    ADD CONSTRAINT "MediaFiles_pkey" PRIMARY KEY ("Id");


--
-- Name: PageElements PageElements_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."PageElements"
    ADD CONSTRAINT "PageElements_pkey" PRIMARY KEY ("Id");


--
-- Name: Pages Pages_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Pages"
    ADD CONSTRAINT "Pages_pkey" PRIMARY KEY ("Id");


--
-- Name: QuestRatings QuestRatings_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."QuestRatings"
    ADD CONSTRAINT "QuestRatings_pkey" PRIMARY KEY ("Id");


--
-- Name: Quests Quests_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Quests"
    ADD CONSTRAINT "Quests_pkey" PRIMARY KEY ("Id");


--
-- Name: Users Users_Email_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Users"
    ADD CONSTRAINT "Users_Email_key" UNIQUE ("Email");


--
-- Name: Users Users_Username_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Users"
    ADD CONSTRAINT "Users_Username_key" UNIQUE ("Username");


--
-- Name: Users Users_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Users"
    ADD CONSTRAINT "Users_pkey" PRIMARY KEY ("Id");


--
-- Name: PageElements PageElements_MediaFileId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."PageElements"
    ADD CONSTRAINT "PageElements_MediaFileId_fkey" FOREIGN KEY ("MediaFileId") REFERENCES public."MediaFiles"("Id") ON DELETE SET NULL;


--
-- Name: PageElements PageElements_PageId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."PageElements"
    ADD CONSTRAINT "PageElements_PageId_fkey" FOREIGN KEY ("PageId") REFERENCES public."Pages"("Id") ON DELETE CASCADE;


--
-- Name: Pages Pages_QuestId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Pages"
    ADD CONSTRAINT "Pages_QuestId_fkey" FOREIGN KEY ("QuestId") REFERENCES public."Quests"("Id") ON DELETE CASCADE;


--
-- Name: QuestRatings QuestRatings_QuestId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."QuestRatings"
    ADD CONSTRAINT "QuestRatings_QuestId_fkey" FOREIGN KEY ("QuestId") REFERENCES public."Quests"("Id") ON DELETE CASCADE;


--
-- Name: QuestRatings QuestRatings_UserId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."QuestRatings"
    ADD CONSTRAINT "QuestRatings_UserId_fkey" FOREIGN KEY ("UserId") REFERENCES public."Users"("Id") ON DELETE CASCADE;


--
-- Name: Quests Quests_AuthorId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Quests"
    ADD CONSTRAINT "Quests_AuthorId_fkey" FOREIGN KEY ("AuthorId") REFERENCES public."Users"("Id") ON DELETE CASCADE;


--
-- Name: Quests Quests_PreviewMediaFileId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Quests"
    ADD CONSTRAINT "Quests_PreviewMediaFileId_fkey" FOREIGN KEY ("PreviewMediaFileId") REFERENCES public."MediaFiles"("Id");


--
-- PostgreSQL database dump complete
--

