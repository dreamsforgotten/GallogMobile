	/* Data SHA1: da124b7302f31bfad5ab1d983ffe1f0f1a4a0e17 */
	.file	"typemap.jm.inc"

	/* Mapping header */
	.section	.data.jm_typemap,"aw",@progbits
	.type	jm_typemap_header, @object
	.p2align	2
	.global	jm_typemap_header
jm_typemap_header:
	/* version */
	.long	1
	/* entry-count */
	.long	2484
	/* entry-length */
	.long	246
	/* value-offset */
	.long	105
	.size	jm_typemap_header, 16

	/* Mapping data */
	.type	jm_typemap, @object
	.global	jm_typemap
jm_typemap:
	.size	jm_typemap, 611065
	.include	"typemap.jm.inc"
